using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //float xMove;
    //float zMove;
    [SerializeField]GameObject mainCamera;
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 2f;
    [SerializeField] int numsJumps = 2;
    //[SerializeField] Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
            movement += mainCamera.transform.forward;
        if (Input.GetKey(KeyCode.S))
            movement -= mainCamera.transform.forward;
        if (Input.GetKey(KeyCode.A))
            movement -= mainCamera.transform.right;
        if (Input.GetKey(KeyCode.D))
            movement += mainCamera.transform.right;
        movement.Normalize();
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
        if (Input.GetKeyDown(KeyCode.Space) && numsJumps != 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0 , rb.velocity.z);
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            numsJumps--;
        }
        /*xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(xMove * speed, 0, zMove * speed);*/
        //transform.rotation = camera.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ground")
            numsJumps = 2;
    }
}
