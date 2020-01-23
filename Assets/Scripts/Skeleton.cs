using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public static bool playerAttack;
    public bool concernsPlayer, death;
    public float speed, jumpForce;
    Animator anim;
    Rigidbody characterRigidbody;
    Collider goblinCollider;
    Vector3 movement;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        goblinCollider = GetComponent<Collider>();
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
            anim.SetBool("walk", true);
        }
        else if (concernsPlayer && !death)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", true);

        }
        else if (!death)
            anim.SetBool("walk", false);
        if (Input.GetKey(KeyCode.Mouse1) && concernsPlayer)
        {
            anim.SetBool("attack", false);
            death = true;
            gameObject.GetComponent<Collider>();
            anim.SetBool("death", true);
            goblinCollider.enabled = false;
            characterRigidbody.useGravity = false;
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
