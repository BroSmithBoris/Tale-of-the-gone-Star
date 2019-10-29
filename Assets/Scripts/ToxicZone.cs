using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToxicZone : MonoBehaviour
{
    public Slider HealthPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            HealthPoint.value -= 0.001f;
    }
}
