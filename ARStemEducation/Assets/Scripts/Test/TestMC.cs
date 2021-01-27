using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System;

public class TestMC : MonoBehaviour
{
    public Button ansABtn, ansBBtn, ansCBtn;
    public Text ansAText, ansBText, ansCText;
    public MCArrayList mc;
    private int index = 0;
    void Start()
    {
        mc = gameObject.GetComponent<MCArrayList>();
        mc.SetCurrentIndex(index);
        Debug.Log("mc list size " + mc.GetSize());
        // init Ans's Text object
        ansAText = ansABtn.GetComponentInChildren<Text>();
        ansBText = ansBBtn.GetComponentInChildren<Text>();
        ansCText = ansCBtn.GetComponentInChildren<Text>();

        Button btnA = ansABtn.GetComponent<Button>();
        Button btnB = ansBBtn.GetComponent<Button>();
        Button btnC = ansCBtn.GetComponent<Button>();

        // init onClickListener
        btnA.onClick.AddListener(() => ButtonCallBack(btnA));
        btnB.onClick.AddListener(() => ButtonCallBack(btnB));
        btnC.onClick.AddListener(() => ButtonCallBack(btnC));
    }
    void Update()
    {
        //OnClick();
    }

    public void ButtonCallBack(Button buttonPressed) 
    {
        if (buttonPressed == ansABtn)
        {
            CheckAns(mc.GetValue(index).ansA, index);
        }   
        if (buttonPressed == ansBBtn)
        {
            CheckAns(mc.GetValue(index).ansB, index);
        }
        if (buttonPressed == ansCBtn)
        {
            CheckAns(mc.GetValue(index).ansC, index);
        }
        CheckIndex();
    }

    private void CheckIndex()
    {
        if(index < mc.GetSize() - 1)
        {
            index += 1;
        }
    }

    private void CheckAns(string selectedAns, int index)
    {
        string ans = mc.GetValue(index).ans;
        if (selectedAns == ans)
        {
            Debug.Log("It is correct answer");
        }
        else
        {
            Debug.Log("It is wrong answer, the corrent ans is " + ans);
        }
    }
}
