using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System;

public class TestMC : MonoBehaviour
{
    public Button ansABtn, ansBBtn, ansCBtn;
    public Text ansAText, ansBText, ansCText, messageText, questionText;
    public GameObject messageObj, questionObj;
    public MCArrayList mc;
    private int index = 0;
    private int count = 0;
    private int score = 0;

    void Start()
    {
        // init a MC arrayList from MCArrayList class
        mc = gameObject.GetComponent<MCArrayList>();
        mc.SetCurrentIndex(index);
        Debug.Log("mc list size " + mc.GetSize());
        // init Question and Ans's Text object
        questionText = questionObj.GetComponent<Text>();
        ansAText = ansABtn.GetComponentInChildren<Text>();
        ansBText = ansBBtn.GetComponentInChildren<Text>();
        ansCText = ansCBtn.GetComponentInChildren<Text>();
        messageText = messageObj.GetComponent<Text>();

        Button btnA = ansABtn.GetComponent<Button>();
        Button btnB = ansBBtn.GetComponent<Button>();
        Button btnC = ansCBtn.GetComponent<Button>();

        // set OnClick listener
        btnA.onClick.AddListener(() => ButtonCallBack(btnA));
        btnB.onClick.AddListener(() => ButtonCallBack(btnB));
        btnC.onClick.AddListener(() => ButtonCallBack(btnC));

        messageObj.SetActive(false);
        questionText.text = mc.GetValue(index).question;
        ansAText.text = mc.GetValue(index).ansA;
        ansBText.text = mc.GetValue(index).ansB;
        ansCText.text = mc.GetValue(index).ansC;
    }
    void Update()
    {

    }

    private void ButtonCallBack(Button buttonPressed)
    {
        if (index < mc.GetSize())
        {
            CheckIndex(buttonPressed);
        }
        if (index == mc.GetSize() - 1 && count == mc.GetSize())
        {
            messageObj.SetActive(true);
            messageText.text = "You finished the MC !! , score is " + score.ToString();
            Debug.Log("You finished the MC !!");
        }
    }

    private void CheckIndex(Button buttonPressed)
    {
        // Counting the last question answer is selected or not
        count += 1;
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
        // Any one of answer is selected, go to the next question
        NextQuestion();
    }

    private void CheckAns(string selectedAns, int index)
    {
        string ans = mc.GetValue(index).ans;
        if (selectedAns == ans)
        {
            Debug.Log("It is correct answer");
            score += 1;
        }
        else
        {
            Debug.Log("It is wrong answer, the corrent ans is " + ans);
        }
    }
    private void NextQuestion()
    {
        if(index< mc.GetSize() - 1)
        {
            index += 1;
        }
        Debug.Log("index =" + index);
        questionText.text = mc.GetValue(index).question;
        ansAText.text = mc.GetValue(index).ansA;
        ansBText.text = mc.GetValue(index).ansB;
        ansCText.text = mc.GetValue(index).ansC;
       
    }
}

