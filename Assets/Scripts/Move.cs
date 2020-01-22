﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static KeyCode left = KeyCode.A;
    public static KeyCode right = KeyCode.D;
    public static KeyCode jump = KeyCode.Space;
    public static KeyCode attack = KeyCode.Mouse0;

    public float speed, jumpForce;
    Animator anim;
    bool isGrounded;
    Rigidbody characterRigidbody;
    Vector3 movement;
    public Goblin goblin;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        int x = 0;
        if (Input.GetKey(right))
            x = 1;
        else if (Input.GetKey(left))
            x = -1;
        movement = new Vector3(0, 0, x);
        if (Input.GetKey(left) || Input.GetKey(right))
            anim.SetBool("walk", true);
        else
            anim.SetBool("walk", false);
        if (Input.GetKey(attack))
            anim.SetBool("attack", true);
        else
            anim.SetBool("attack", false);
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
        {
            anim.SetBool("jump", false);
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        //anim.SetBool("jump", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Player_attack")
        {
            goblin.playerAttack = true;
        }
    }

    void CharacterJump(Vector3 direction)
    {
        if (isGrounded && Input.GetKey(jump))
        {
            characterRigidbody.velocity = new Vector3(0, 0, 0);
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("jump", true);
            isGrounded = false;
        }
    }

    void CharacterMove(Vector3 direction)
    {
        characterRigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}