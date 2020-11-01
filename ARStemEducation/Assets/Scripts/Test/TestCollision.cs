using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        Debug.Log("two elements has collised");
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger entered name : " + collider.name);
    }
}
