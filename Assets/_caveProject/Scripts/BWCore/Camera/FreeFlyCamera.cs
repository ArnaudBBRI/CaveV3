//===========================================================================//
//                       FreeFlyCamera (Version 1.2)                         //
//                        (c) 2019 Sergey Stafeyev                           //
//===========================================================================//
//                                                                           //
//                Slightly modified to fit Buildwise's needs.                //
//                                                                           //
//===========================================================================//

using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCamera : MonoBehaviour
{
    #region UI

    [Space]

    [SerializeField]
    [Tooltip("The script is currently active")]
    private bool _active = true;

    [Space]

    [SerializeField]
    [Tooltip("Camera rotation by mouse movement is active")]
    private bool _enableRotation = true;

    [SerializeField]
    [Tooltip("Sensitivity of mouse rotation")]
    private float _mouseSense = 0.3f;

    [Space]

    [SerializeField]
    [Tooltip("Camera zooming in/out by 'Mouse Scroll Wheel' is active")]
    private bool _enableTranslation = true;

    [SerializeField]
    [Tooltip("Velocity of camera zooming in/out")]
    private float _translationSpeed = 55f;

    [Space]

    [SerializeField]
    [Tooltip("Camera movement by 'W','A','S','D','Q','E' keys is active")]
    private bool _enableMovement = true;

    [SerializeField]
    [Tooltip("Camera movement speed")]
    private float _movementSpeed = 10f;

    [SerializeField]
    [Tooltip("Speed of the quick camera movement when holding the 'Left Shift' key")]
    private float _boostedSpeed = 50f;

    [SerializeField]
    [Tooltip("Boost speed")]
    private KeyCode _boostSpeed = KeyCode.LeftShift;

    [Space]

    [SerializeField]
    [Tooltip("Acceleration at camera movement is active")]
    private bool _enableSpeedAcceleration = true;

    [SerializeField]
    [Tooltip("Rate which is applied during camera movement")]
    private float _speedAccelerationFactor = 1.5f;

    [Space]

    [SerializeField]
    [Tooltip("This keypress will move the camera to initialization position")]
    private KeyCode _initPositonButton = KeyCode.R;

    #endregion UI

    private CursorLockMode _wantedMode;
    private bool _hasEscBeenPressedRecently = false;

    private float _currentIncrease = 1;
    private float _currentIncreaseMem = 0;

    private Vector3 _initPosition;
    private Vector3 _initRotation;

    private BWControls controls;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_boostedSpeed < _movementSpeed)
            _boostedSpeed = _movementSpeed;
    }
#endif


    private void Awake()
    {
        controls = ControlsManager.BWControls;
        controls.InGame.restart.performed += ctx => ResetPosition();
        controls.InGame.changeCursorMode.performed += ctx => SetCursorState();
    }



    private void Start()
    {
        _initPosition = transform.position;
        _initRotation = transform.eulerAngles;
    }

    private void OnEnable()
    {
        if (_active)
            _wantedMode = CursorLockMode.None;
    }

    // Apply requested cursor state
    private void SetCursorState()
    {
        if (_hasEscBeenPressedRecently)
        {
            _wantedMode = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = _wantedMode = CursorLockMode.None;
            _hasEscBeenPressedRecently = true;
            StartCoroutine(RecordEscKeyForAMoment());
        }

        // Apply cursor state
        Cursor.lockState = _wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != _wantedMode);
    }

    private IEnumerator RecordEscKeyForAMoment()
    {
        yield return new WaitForSeconds(0.5f);
        _hasEscBeenPressedRecently = false;
    }
    
    private void CalculateCurrentIncrease(bool moving)
    {
        _currentIncrease = Time.deltaTime;

        if (!_enableSpeedAcceleration || _enableSpeedAcceleration && !moving)
        {
            _currentIncreaseMem = 0;
            return;
        }

        _currentIncreaseMem += Time.deltaTime * (_speedAccelerationFactor - 1);
        _currentIncrease = Time.deltaTime + Mathf.Pow(_currentIncreaseMem, 3) * Time.deltaTime;
    }

    private void Update()
    {
        if (!_active)
            return;

        //SetCursorState();

        /*
        if (Cursor.visible)
            return;
        */
        // Translation
        if (_enableTranslation)
        {
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * _translationSpeed);
        }

        // Movement
        Vector2 moveVector = controls.InGame.move.ReadValue<Vector2>();
        Vector2 lookVector = controls.InGame.look.ReadValue<Vector2>();
        float upDownVector = controls.InGame.verticalMove.ReadValue<float>();
        
        if (_enableMovement && (moveVector != Vector2.zero || upDownVector != 0.0f))
        {
            Vector3 deltaPosition = Vector3.zero;
            float currentSpeed = _movementSpeed;

            if (Input.GetKey(_boostSpeed))
                currentSpeed = _boostedSpeed;
            if (moveVector.y > 0)
                deltaPosition += transform.forward;
            if (moveVector.y < 0)
                deltaPosition -= transform.forward;
            if (moveVector.x < 0)
                deltaPosition -= transform.right;
            if (moveVector.x > 0)
                deltaPosition += transform.right;
            if (upDownVector > 0)
                deltaPosition += transform.up;
            if (upDownVector < 0)
                deltaPosition -= transform.up;

            // Calc acceleration
            CalculateCurrentIncrease(deltaPosition != Vector3.zero);
            transform.position += deltaPosition * currentSpeed * _currentIncrease;
        }

        // Rotation
        if (_enableRotation)
        {
            // Pitch
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + lookVector.x * _mouseSense, transform.eulerAngles.z);
            // Paw
            transform.rotation *= Quaternion.AngleAxis(lookVector.y * _mouseSense, Vector3.right);
        }
    }

    private void ResetPosition()
    {
        transform.position = _initPosition;
        transform.eulerAngles = _initRotation;
    }
}
