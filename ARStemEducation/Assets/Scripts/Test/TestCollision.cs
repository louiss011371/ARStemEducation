using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Check two trigger objects are collided
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger entered name : " + collider.name);
        if(collider.name == "Fe" || collider.name == "S")
        {
            Destroy(collider.gameObject);
        }
    }
}
