using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBar : MonoBehaviour
{
    GameObject onOffButton;
    public GameObject bulbObj;
    GameObject bulbLight;
    public Material lightOnMaterial;
    public Material lightOffMaterial;
    public GameObject electricElementsMove;
    bool shouldMove;
    public Button btn;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        onOffButton = this.gameObject;
        Debug.Log("SwitchBar loaded");
        bulbObj = GameObject.Find("Bulb");
        bulbLight = bulbObj.gameObject.transform.GetChild(0).gameObject;
        shouldMove = false;
        text = btn.GetComponentInChildren<Text>();
        text.text = "Switch On";
    }

    private void Update()
    {
        ShouldMove();
    }

    public void OnClick()
    {
        if (text.text == "Switch On")
        {
            StatusOn();
        } else if(text.text == "Switch Off")
        {
            StatusOff();
        }
    }
    // Light On
    public void StatusOn() 
    {
        if (onOffButton.transform.localRotation.z < -0.17)
        {
            onOffButton.transform.Rotate(0, 0, 20);
            bulbLight.GetComponent<MeshRenderer>().material = lightOnMaterial;
            shouldMove = true;
            text.text = "Switch Off";
        }
    }
    // Light Off
    public void StatusOff() 
    {
        if (onOffButton.transform.localRotation.z * 1000000 > -0.07)
        {
            onOffButton.transform.Rotate(0, 0, -20);
            bulbLight.GetComponent<MeshRenderer>().material = lightOffMaterial;
            shouldMove = false;
            text.text = "Switch On";
        }
    }
    public void ShouldMove()
    {
        if(shouldMove)
        {
            electricElementsMove.GetComponent<ElectricElementsMove>().Move();
        }
    }
}
