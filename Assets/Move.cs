using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    #region
    //KeyCode left = KeyCode.A;
    //KeyCode right = KeyCode.D;
    //KeyCode jump = KeyCode.Space;

    //public float speed, jumpForce;
    //public LayerMask groundLayers;

    //SphereCollider characterCollider;
    //Rigidbody characterRigidbody;
    //bool isGrounded;

    //void Start()
    //{
    //    characterCollider = GetComponent<SphereCollider>();
    //    characterRigidbody = GetComponent<Rigidbody>();
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == ("Ground") && isGrounded == false)
    //    {
    //        isGrounded = true;
    //    }
    //}

    //void FixedUpdate()
    //{
    //    int x;
    //    if (Input.GetKey(right))
    //        x = 1;
    //    else if (Input.GetKey(left))
    //        x = -1;
    //    else
    //        x = 0;

    //    Vector3 movement = new Vector3(x, 0, 0);

    //    characterRigidbody.AddForce(movement * speed);

    //    if (isGrounded && Input.GetKeyDown(jump))
    //    {
    //        characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }
    //}
    #endregion

    public float jumpSpeed = 5f;
    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 2, 0) * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}