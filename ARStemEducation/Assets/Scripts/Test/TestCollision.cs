using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    public Animator anim;
    public GameObject feObj, sObj;
    public GameObject fesTextObj;
    private void Start()
    {
        //anim = GetComponent<Animator>();
        anim.Play("None");
        fesTextObj.SetActive(false);
    }
    private void Update()
    {
       if(Input.GetKey("a"))
        {
            anim.Play("Burning");
            fesTextObj.SetActive(true);
        }
       if(sObj != null)
        {
            ChangeElement();
        }
        else
        {
            ChangeColor();
        }
    }

    // if Fe element position is equal to S element
    private void ChangeElement()
    {
        if (feObj.transform.localPosition == sObj.transform.localPosition)
        {
            Debug.Log("Fe and S merged");
            Destroy(sObj);
        }
    }
    private void ChangeColor()
    {
        anim.Play("ChangeColor");
        Debug.Log("ChangeColor() play");
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
