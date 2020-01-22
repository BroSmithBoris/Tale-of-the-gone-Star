using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour
{
    NavMeshAgent friend;
    GameObject player;
    public float distance;
    public float speed;
    public float speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        friend = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            Vector3 rotation = player.transform.position - friend.transform.position;
            friend.transform.rotation = Quaternion.Slerp(friend.transform.rotation, Quaternion.LookRotation(rotation), speedRotation * Time.deltaTime);
            friend.transform.position += friend.transform.forward * speed * Time.deltaTime;
            friend.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 5.5f);
            friend.transform.localRotation = new Quaternion(0f, transform.position.y, 0f, transform.rotation.w);
        }
    }
}
