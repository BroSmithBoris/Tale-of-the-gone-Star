﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public bool playerAttack, concernsPlayer, death;
    public float speed, jumpForce;
    public Animation anim;
    public AnimationClip animClip;
    Rigidbody characterRigidbody;
    Vector3 movement;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }

    private void OnTriggerStay(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Player")
            concernsPlayer = true;
    }

    void OnTriggerExit(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Player")
            concernsPlayer = false;
    }

    void Update()
    {
        int x = 0;
        if (playerAttack && !concernsPlayer && !death)
        {
            x = -1;
            anim.Play("run");
        }
        else if (concernsPlayer && !death)
            anim.Play("attack1");
        else if (!death)
            anim.Play("idle");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            death = true;
            anim.Play("death");
        }
        movement = new Vector3(0, 0, x);
    }

    void FixedUpdate()
    {
        CharacterMove(movement);
    }

    void CharacterMove(Vector3 direction)
    {
        characterRigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
