using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compound : MonoBehaviour
{
    public Button potassiumBtnObj, sodiumBtnObj, calciumBtnObj, copperBtnObj;
    public GameObject greenFlameObj, redFlameObj, whiteFlameObj, yellowFlameObj;
    
    // Start is called before the first frame update
    void Start()
    {
        // set OnClick listener
        potassiumBtnObj.onClick.AddListener(() => ButtonCallBack(potassiumBtnObj));
        sodiumBtnObj.onClick.AddListener(() => ButtonCallBack(sodiumBtnObj));
        calciumBtnObj.onClick.AddListener(() => ButtonCallBack(calciumBtnObj));
        copperBtnObj.onClick.AddListener(() => ButtonCallBack(copperBtnObj));

        // init Compound Flame is hidden
        greenFlameObj.SetActive(false);
        redFlameObj.SetActive(false);
        whiteFlameObj.SetActive(false);
        yellowFlameObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ButtonCallBack(Button buttonPressed)
    {
        if(buttonPressed == potassiumBtnObj)
        {
            whiteFlameObj.SetActive(true);

            greenFlameObj.SetActive(false);
            redFlameObj.SetActive(false);
            yellowFlameObj.SetActive(false);
        } else if (buttonPressed == sodiumBtnObj)
        {
            yellowFlameObj.SetActive(true);

            greenFlameObj.SetActive(false);
            redFlameObj.SetActive(false);
            whiteFlameObj.SetActive(false);
        } else if (buttonPressed == calciumBtnObj)
        {
            redFlameObj.SetActive(true);

            greenFlameObj.SetActive(false);
            whiteFlameObj.SetActive(false);
            yellowFlameObj.SetActive(false);

        } else if (buttonPressed == copperBtnObj)
        {
            greenFlameObj.SetActive(true);

            redFlameObj.SetActive(false);
            whiteFlameObj.SetActive(false);
            yellowFlameObj.SetActive(false);
        }
    } 
}
