using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    private Animator anim = null;
    public Button leftBtn;
    public Button rightBtn;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("LeftArrowOnClick", false);
        anim.SetBool("RightArrowOnClick", false);
    }
    void Update()
    {
    }

    public void ElementLeftRotation()
    {
        anim.SetBool("RightArrowOnClick", false);
        Debug.Log("left click");
        anim.SetBool("LeftArrowOnClick", true);
        //if (anim.Get)
    }

    public void ElementRightRotation()
    {
        anim.SetBool("LeftArrowOnClick", false);
        Debug.Log("right click");
        anim.SetBool("RightArrowOnClick", true);
    }
}
