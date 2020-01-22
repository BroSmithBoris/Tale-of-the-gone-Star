using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static KeyCode left = KeyCode.A;
    public static KeyCode right = KeyCode.D;
    public static KeyCode jump = KeyCode.Space;

    public float speed, jumpForce;

    bool isGrounded;
    Rigidbody characterRigidbody;
    Vector3 movement;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        int x = 0;
        if (Input.GetKey(right))
            x = 1;
        else if (Input.GetKey(left))
            x = -1;
        movement = new Vector3(x, 0, 0);
    }

    void FixedUpdate()
    {
        CharacterJump(movement);
        CharacterMove(movement);
    }

    void OnCollisionStay(Collision collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void CharacterJump(Vector3 direction)
    {
        if (isGrounded && Input.GetKey(jump))
        {
            characterRigidbody.velocity = new Vector3(0, 0, 0);
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void CharacterMove(Vector3 direction)
    {
        characterRigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}