using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ElementsOnClick : MonoBehaviour
{
    public GameObject h2oObj, waterElectObj, electFormula;

    private void Start()
    {
        //h2oObj = GameObject.Find("H2O");
        //waterElectObj = GameObject.Find("Electrolysis");
       // vButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);

    }

    //public void OnButtonPressed(VirtualButtonBehaviour vb)
    //{
    //    //throw new System.NotImplementedException();
    //    //h2oObj.SetActive(false);
    //    //waterElectObj.SetActive(true);
    //    //electFormula.SetActive(true);
    //}

    //public void OnButtonReleased(VirtualButtonBehaviour vb)
    //{
    //    //throw new System.NotImplementedException();
    //    //waterElectObj.SetActive(false);
    //    //electFormula.SetActive(false);
    //    //h2oObj.SetActive(true);
    //}
    private void Update()
    {
        for(int i = 0; i< Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began && h2oObj.activeSelf == true)
            {
                h2oObj.SetActive(false);
                waterElectObj.SetActive(true);
                electFormula.SetActive(true);
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Began && waterElectObj.activeSelf == true)
            {
                waterElectObj.SetActive(false);
                electFormula.SetActive(false);
                h2oObj.SetActive(true);
            }
        }
    }

    //public void onClick()
    //{

    //}
}
