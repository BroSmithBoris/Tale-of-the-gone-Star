using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{
    public static bool playerAttack;
    public bool concernsPlayer, death;
    public float speed, jumpForce;
    public Animation anim;
    public AnimationClip animClip;
    Rigidbody characterRigidbody;
    Collider goblinCollider;
    Vector3 movement;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
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
            anim.Play("run");
        }
        else if (concernsPlayer && !death)
        {          
            anim.Play("attack1");
        }
        else if (!death)
            anim.Play("idle");
        if (Input.GetKey(KeyCode.Mouse1) && concernsPlayer)
        {
            death = true;
            gameObject.GetComponent<Collider>();
            anim.Play("death");
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
