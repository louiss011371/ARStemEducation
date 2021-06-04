using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System;

public class TestMC : MonoBehaviour
{
    public Button ansABtn, ansBBtn, ansCBtn, ansDBtn;
    public Text ansAText, ansBText, ansCText, ansDText, messageText;
    public GameObject messageObj;
    public Image messagePanel;
    public MCArrayList mc;
    public Image questionimage;
    public Sprite indexQuestionImage;
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
        ansAText = ansABtn.GetComponentInChildren<Text>();
        ansBText = ansBBtn.GetComponentInChildren<Text>();
        ansCText = ansCBtn.GetComponentInChildren<Text>();
        ansDText = ansDBtn.GetComponentInChildren<Text>();
        messageText = messageObj.GetComponent<Text>();

        Button btnA = ansABtn.GetComponent<Button>();
        Button btnB = ansBBtn.GetComponent<Button>();
        Button btnC = ansCBtn.GetComponent<Button>();
        Button btnD = ansDBtn.GetComponent<Button>();

        // set OnClick listener
        btnA.onClick.AddListener(() => ButtonCallBack(btnA));
        btnB.onClick.AddListener(() => ButtonCallBack(btnB));
        btnC.onClick.AddListener(() => ButtonCallBack(btnC));
        btnD.onClick.AddListener(() => ButtonCallBack(btnD));
        messagePanel.gameObject.SetActive(false);
        questionimage.sprite = mc.GetValue(index).questionImage;
        //newImage.GetComponent<SpriteRenderer>().sprite = mc.GetValue(index).questionImage;
        ansAText.text = mc.GetValue(index).ansA;
        ansBText.text = mc.GetValue(index).ansB;
        ansCText.text = mc.GetValue(index).ansC;
        ansDText.text = mc.GetValue(index).ansD;
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
            messagePanel.gameObject.SetActive(true);
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
        if (buttonPressed == ansDBtn)
        {
            CheckAns(mc.GetValue(index).ansD, index);
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
        ansAText.text = mc.GetValue(index).ansA;
        ansBText.text = mc.GetValue(index).ansB;
        ansCText.text = mc.GetValue(index).ansC;
        ansDText.text = mc.GetValue(index).ansD;
        questionimage.sprite = mc.GetValue(index).questionImage;
    }
}

