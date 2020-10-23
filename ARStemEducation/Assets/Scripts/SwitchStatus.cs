using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStatus : MonoBehaviour
{
    GameObject onOffButton;
    public GameObject bulbObj;
    GameObject bulbLight;
    public Material lightOnMaterial;
    public Material lightOffMaterial;

    private void Start()
    {
        Debug.Log("SwtichStatus loaded");
        onOffButton = this.gameObject.transform.GetChild(0).gameObject;
        bulbObj = GameObject.Find("Bulb");
        bulbLight = bulbObj.gameObject.transform.GetChild(0).gameObject;
    }
 
    void Update()
    {
        SwitchController();
    }

    public void SwitchController()
    {
        if (Input.GetKeyDown("w"))
        {
            Debug.Log("before w key down " + onOffButton.transform.localPosition.z);
            StatusOn();
            Debug.Log("after w key down " + onOffButton.transform.localPosition.z);
        }
        if (Input.GetKeyDown("s"))
        {
            StatusOff();
        }
    }

    public void StatusOn()
    {
        if(onOffButton.transform.localPosition.z <0) {
            onOffButton.transform.localPosition = new Vector3(onOffButton.transform.localPosition.x , onOffButton.transform.localPosition.y, onOffButton.transform.localPosition.z +0.7f);
            bulbLight.GetComponent<MeshRenderer>().material = lightOnMaterial;
        }
    }

    public void StatusOff()
    {
        onOffButton.transform.localPosition = new Vector3(onOffButton.transform.localPosition.x, onOffButton.transform.localPosition.y, -0.7f);
        bulbLight.GetComponent<MeshRenderer>().material = lightOffMaterial;
    }

    public void BulbLight()
    {

    }
}
