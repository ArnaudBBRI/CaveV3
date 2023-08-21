//using Buildwise.BIM;
using UnityEngine;
using Buildwise.Core;
using System.Collections;
using UnityEngine.UI;

namespace Buildwise.Hovering
{
    public class SuggestObjectChangeOnHovering : MonoBehaviour//, IHoveringResponse
    {
        [SerializeField] private GameObject _furnitureSwitchMenu;
        private Camera _camera;
        private HelperFunctions _helperFunctions;
        private Coroutine _keepMenu;
        private Button _switchFurnitureButton;

        //public IntReference HoveredSwitchableObjectInstanceID;

        //public IntGameEvent ActionIntEvent;

        private void Start()
        {
            _camera = Camera.main;
            _helperFunctions = new HelperFunctions();
            //ActionIntEvent.AddListener(EmulateClickButton);
            _switchFurnitureButton = _furnitureSwitchMenu.GetComponentInChildren<Button>();
        }

        public void ClearResponse(Transform selection)
        {
            if (_keepMenu != null)
            {
                StopCoroutine(_keepMenu);
                _keepMenu = null;
            }
            if (_furnitureSwitchMenu != null)
            {
                _furnitureSwitchMenu.SetActive(false);
            }
        }

        public void OnDeselect(Transform selection)
        {
            if (_keepMenu == null)
            {
                _keepMenu = StartCoroutine(KeepMenuOnAFewSeconds(2.0f, selection));
            }
        }

        public void OnMaterialChange()
        {
            throw new System.NotImplementedException();
        }
        /*
        public void OnSelect(Transform selection)
        {
            if (selection.TryGetComponent(out ISwitchableObject iso) == false) return;
            else
            {
                ClearResponse(selection);
                Debug.Log($"Showing furniture switch menu for {selection}");
                ShowFurnitureSwitchMenu(selection);
                Debug.Log($"Assigning {selection.gameObject.GetInstanceID()} to HoveredSwitchableObjectInstanceID.Value");
                HoveredSwitchableObjectInstanceID.Value = selection.gameObject.GetInstanceID();
            }
        }
        */

        private void ShowFurnitureSwitchMenu(Transform selection)
        {
            var menuPosition = ComputeMenuPosition(selection);
            _furnitureSwitchMenu.SetActive(true);
            _furnitureSwitchMenu.transform.position = menuPosition;
            AdjustMenuOrientation();
        }

        private void EmulateClickButton(int action)
        {
            if (_furnitureSwitchMenu.activeSelf)
            {
                _switchFurnitureButton.onClick.Invoke();
            }
        }

        private void AdjustMenuOrientation()
        {
            _furnitureSwitchMenu.transform.LookAt(_furnitureSwitchMenu.transform.position + _camera.transform.rotation * Vector3.forward,
                _camera.transform.rotation * Vector3.up);
        }

        private Vector3 ComputeMenuPosition(Transform selection)
        {
            var worldCorners = _helperFunctions.GetBoundingBoxCorners(selection);
            Vector3 worldMostRightCorner = _helperFunctions.GetMostRightPointAsSeenFromCamera(_camera, worldCorners);
            Vector3 worldHighestCorner = _helperFunctions.GetHighestPointAsSeenFromCamera(_camera, worldCorners);
            Vector3 worldClostestCorner = _helperFunctions.GetClosestPointAsSeenFromCamera(_camera, worldCorners);
            Vector3 menuAnchorPoint = new Vector3(worldMostRightCorner.x, worldHighestCorner.y, worldMostRightCorner.z);

            float moveDistance = Mathf.Abs(_camera.WorldToScreenPoint(menuAnchorPoint).z - _camera.WorldToScreenPoint(worldClostestCorner).z);
            Vector3 moveDirection = _camera.transform.position - menuAnchorPoint;
            moveDirection.Normalize();

            menuAnchorPoint = menuAnchorPoint + moveDirection * moveDistance * 1.1f;

            return menuAnchorPoint;
        }


        private IEnumerator KeepMenuOnAFewSeconds(float duration, Transform selection)
        {
            if (_furnitureSwitchMenu == null) yield return null;
            else
            {
                var startTime = Time.time;
                var elapsedTime = 0f;
                while (elapsedTime < duration)
                {
                    _furnitureSwitchMenu.transform.position = ComputeMenuPosition(selection);
                    AdjustMenuOrientation();
                    elapsedTime = Time.time - startTime;
                    yield return null;
                }
            }
            ClearResponse(selection);
        }
    }
}
