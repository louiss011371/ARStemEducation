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
            Debug.Log("before w key down " + Quaternion.Euler(onOffButton.transform.rotation.x, onOffButton.transform.rotation.y, onOffButton.transform.rotation.z));
            StatusOff();
            Debug.Log("after w key down " + onOffButton.transform.localRotation.x);

        }
        if (Input.GetKeyDown("s"))
        {
            Debug.Log("before s key down " + onOffButton.transform.rotation.x);
            StatusOn();
            Debug.Log("after s key down " + onOffButton.transform.rotation.x);
        }
    }

    public void StatusOn()
    {
        if (onOffButton.transform.localRotation.x * 10 > 1.7)
        {
            onOffButton.transform.Rotate(-20, 0, 0);
            bulbLight.GetComponent<MeshRenderer>().material = lightOnMaterial;
        }
    }

    public void StatusOff()
    {
        if (onOffButton.transform.localRotation.x < 0.17)
        {

            onOffButton.transform.Rotate(20, 0, 0);

            bulbLight.GetComponent<MeshRenderer>().material = lightOffMaterial;
        }
    }
}
