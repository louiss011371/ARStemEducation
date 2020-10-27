using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ElementsOnClick : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject h2oObj, waterElectObj, electFormula, vButton;

    private void Start()
    {
        //h2oObj = GameObject.Find("H2O");
        //waterElectObj = GameObject.Find("Electrolysis");
        vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
        h2oObj.SetActive(false);
        waterElectObj.SetActive(true);
        electFormula.SetActive(true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);
        h2oObj.SetActive(true);
    }
}
