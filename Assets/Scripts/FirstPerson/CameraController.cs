using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//Script defines camera's motion and POV. Links cam to mouse movements
//

public class CameraController : MonoBehaviour
{
    //sensitivity
    public float sensX;
    public float sensY;

    public Transform orientation;

    public bool canLook = false;

    //rotation
    float rotX;
    float rotY;

    //cursor visibility and orientation
    private void Start()
    {
        //cursor is not locked until start button is pressed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (!canLook) return;

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

    public void setLookEnabled(bool on)
    {
        canLook = on;

        Cursor.lockState = on ? CursorLockMode.Locked :
        CursorLockMode.None;
        Cursor.visible = !on;
    }
}
