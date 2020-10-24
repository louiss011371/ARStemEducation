using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARElementRotate : MonoBehaviour
{
   GameObject hTwoOBoj;
    //OnCLickListener script;

    private void Start()
    {
        hTwoOBoj = GameObject.Find("H2OAR");
        //hTwoOBoj = this.gameObject;
        Debug.Log(hTwoOBoj);
       // script = new OnCLickListener();
    }

    public void RotateLeft()
    {      
        Debug.Log("RotateLeft");
        hTwoOBoj.gameObject.transform.Rotate(0, -1, 0);
       // script.TestPrint();
    }

    public void RotateRight()
    {
        Debug.Log("RotateRight");
        hTwoOBoj.gameObject.transform.Rotate(0, 1, 0);
    }
}
