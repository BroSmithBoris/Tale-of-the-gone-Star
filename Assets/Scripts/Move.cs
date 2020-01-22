using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static KeyCode left = KeyCode.A;
    public static KeyCode right = KeyCode.D;
    public static KeyCode jump = KeyCode.Space;

    public bool IsGrounded;
    public Rigidbody CharacterRigidbody;

    LedgeGrab ledgeGrab;
    public float speed, jumpForce;
    Vector3 movement;
    Vector3 trajectory;

    void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
        ledgeGrab = GetComponent<LedgeGrab>();
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
            IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }

    void CharacterJump(Vector3 direction)
    {
        bool freezePlayer = CharacterRigidbody.constraints is RigidbodyConstraints.FreezeAll;
        if ((IsGrounded || freezePlayer) && Input.GetKey(jump))
        {
            CharacterRigidbody.constraints = (RigidbodyConstraints)120;
            ledgeGrab.canGrub = true;
            CharacterRigidbody.velocity = new Vector3(0, 0, 0);
            if (freezePlayer)
                CharacterRigidbody.MovePosition(transform.position + (new Vector3(-5, 0, 0) * speed * Time.deltaTime));
            CharacterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsGrounded = false;
        }
    }

    void CharacterMove(Vector3 direction)
    {
        CharacterRigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}