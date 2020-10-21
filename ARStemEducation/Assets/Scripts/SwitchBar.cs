using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBar : MonoBehaviour
{
    GameObject onOffButton;
    public GameObject bulbObj;
    GameObject bulbLight;
    public Material lightOnMaterial;
    public Material lightOffMaterial;
    // Start is called before the first frame update
    void Start()
    {
        onOffButton = this.gameObject;
        Debug.Log("SwtichStatus loaded");
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
            Debug.Log("before w key down " + onOffButton.transform.rotation.z);
            StatusOff();
            Debug.Log("after w key down " + onOffButton.transform.localRotation.z);

        }
        if (Input.GetKeyDown("s"))
        {
            Debug.Log("before s key down " + onOffButton.transform.rotation.z);
          
            StatusOn();
            Debug.Log("after s key down " + onOffButton.transform.rotation.z * 1000000);
          
        }
    }

    public void StatusOn()
    {
        if (onOffButton.transform.localRotation.z < -0.17)
        {
            onOffButton.transform.Rotate(0, 0, 20);
            bulbLight.GetComponent<MeshRenderer>().material = lightOnMaterial;
        }
    }

    public void StatusOff()
    {

        if (onOffButton.transform.localRotation.z * 1000000 > -0.07)
        {

            onOffButton.transform.Rotate(0, 0, -20);

            bulbLight.GetComponent<MeshRenderer>().material = lightOffMaterial;
        }
    }
}
