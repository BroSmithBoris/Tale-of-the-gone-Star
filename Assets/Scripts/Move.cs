using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{ 
    public static KeyCode left = KeyCode.A;
    public static KeyCode right = KeyCode.D;
    public static KeyCode jump = KeyCode.Space;

    public float speed, speedLimit, jumpForce;
    public LayerMask groundLayers;

    SphereCollider characterCollider;
    Rigidbody characterRigidbody;
    bool isGrounded;

    void Start()
    {
        characterCollider = GetComponent<SphereCollider>();
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        int x = 0;
        if (characterRigidbody.velocity.x < speedLimit)
            if (Input.GetKey(right))
                x = 1;
            else if (characterRigidbody.velocity.x > -speedLimit)
                if (Input.GetKey(left))
                    x = -1;

        Vector3 movement = new Vector3(x, 0, 0);

        characterRigidbody.AddForce(movement * speed, ForceMode.Impulse);


        if (isGrounded && Input.GetKeyDown(jump))
        {
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}