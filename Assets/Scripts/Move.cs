using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    KeyCode jump = KeyCode.Space;

    public float speed, jumpForce;
    public LayerMask groundLayers;

    Rigidbody characterRigidbody;
    bool isGrounded;
    Vector3 movement;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
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

    void CharacterJump(Vector3 direction)
    {
        if (isGrounded && Input.GetKeyDown(jump))
        {
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void CharacterMove(Vector3 direction)
    {
        characterRigidbody.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }
}