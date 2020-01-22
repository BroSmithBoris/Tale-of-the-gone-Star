using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    Move player;
    public int constraints;
    public bool canGrub;

    //void OnTriggerExit(Collider other)
    //{
    //    var tag = other.gameObject.tag;
    //    if (tag == "Ledge")
    //        canGrub = true;
    //}

    void OnCollisionEnter(Collision other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Ledge" && canGrub)
        {
            player.CharacterRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            canGrub = false;
            player.IsGrounded = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        constraints = (int)player.CharacterRigidbody.constraints;
    }
}
