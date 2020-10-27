using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ElementsOnClick : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject model, vButton;

    private void Start()
    {
        model = GameObject.Find("H2O");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
        model.gameObject.transform.Rotate(0, 90, 0);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
        model.gameObject.transform.Rotate(0, 0, 0);
    }
}
