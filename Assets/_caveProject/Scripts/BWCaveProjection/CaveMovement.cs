using UnityEngine;
using UVRPN.Core;

public class CaveMovement : MonoBehaviour
{
    [SerializeField] private GameObject flystick;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed=20f;
    private Vector3 forwardDirection;
    private Vector2 joystick;
    VRPN_Analog analog;

    // Start is called before the first frame update
    void Start()
    {
        analog = FindObjectOfType<VRPN_Analog>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardDirection = flystick.transform.forward;
        joystick = analog.Analog;
        transform.position += forwardDirection * Time.deltaTime * moveSpeed * joystick.y;
        transform.Rotate(Vector3.up *Time.deltaTime * rotationSpeed * joystick.x);
    }
}
