using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //KeyCode up = KeyCode.W;
    //KeyCode down = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    public float speed;
    public float gravity = 20.0f;
    //Animator anim;


    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
            //int x;
            int x;

            if (Input.GetKey(right))
                x = 1;
            else if (Input.GetKey(left))
                x = -1;
            else
                x = 0;

            moveDirection = new Vector3(x, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            //if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
            //    anim.SetBool("walk", true);
            //else
            //    anim.SetBool("walk", false);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}