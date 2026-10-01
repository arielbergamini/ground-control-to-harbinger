using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //sensitivity
    public float sensX;
    public float sensY;

    public Transform orientation;

    //rotation
    float rotX;
    float rotY;

    //cursor visibility and orientation
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


        rotY += mouseX;

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90f, 90f); //so we can only look 90deg in any direction

        //rotate cam and player orientation
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
