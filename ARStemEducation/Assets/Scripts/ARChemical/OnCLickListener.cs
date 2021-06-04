using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCLickListener : MonoBehaviour
{
    ARElementRotate arElementRotate;
    public GameObject hTwoOElement;
    bool shouldTotateLeft;
    bool shouldTotateRight;
    public Button leftButtonObj;
    public Button rightButtonObj;
    // Start is called before the first frame update
    void Start()
    {
        arElementRotate = gameObject.AddComponent<ARElementRotate>();
        hTwoOElement = GameObject.Find("H2OAR");
        Debug.Log("OnCLickListener start");
        shouldTotateLeft = false;
        shouldTotateRight = false;

        Button leftButton =  leftButtonObj.GetComponent<Button>();
        Button rightButton = rightButtonObj.GetComponent<Button>();
        leftButton.onClick.AddListener(LeftClick);
        rightButton.onClick.AddListener(RightClick);

    }

    // Update is called once per frame
    void Update()
    {
        ShouldRotate();
    }
    public void LeftClick()
    {
        shouldTotateRight = false;
        shouldTotateLeft = true;
        Debug.Log("OnCLickListener start");
    }

    public void RightClick()
    {
        shouldTotateLeft = false;
        shouldTotateRight = true;
        Debug.Log("OnCLickListener start");
    }

    public void ShouldRotate()
    {
        if (shouldTotateLeft)
        {
            arElementRotate.RotateLeft();
            Debug.Log("rotate left ing");
        } else if (shouldTotateRight)
        {
            arElementRotate.RotateRight();
            Debug.Log("rotate right ing");
        }
    }
}
