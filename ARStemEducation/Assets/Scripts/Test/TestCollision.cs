using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        //anim = GetComponent<Animator>();
        anim.Play("None");
    }
    private void Update()
    {
       if(Input.GetKey("a"))
        {
            Debug.Log("input a was detected");
            anim.Play("Burning");
        }
    }
    // Check two trigger objects are collided
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger entered name : " + collider.name);
        if(collider.name == "Fe" || collider.name == "S")
        {
           // Destroy(collider.gameObject);
        }
    }
}
