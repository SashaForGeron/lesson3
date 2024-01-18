using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float xMouse;
    float yMouse;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(-yMouse, xMouse, 0f);
    }
}
