using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreLineLength : MonoBehaviour
{
    private string bcLineLengthStr, acLineLengthStr;
    [SerializeField]
    private GameObject bcLineLengthInputField, acLineLengthInputField;
    [SerializeField]
    private Text bcLineLengthTextView, acLineLengthTextView;

    private void Start()
    {
        bcLineLengthStr = "2.8";
        acLineLengthStr = "-4";
    }
    public void StoreLinesLength()
    {
        bcLineLengthStr = bcLineLengthInputField.GetComponent<Text>().text;
        acLineLengthStr = acLineLengthInputField.GetComponent<Text>().text;

        bcLineLengthTextView.text = bcLineLengthStr;
        acLineLengthTextView.text = acLineLengthStr;
    }

    public float GetBCLineLength()
    {
        return float.Parse(bcLineLengthStr);
    }
    public float GetACLineLength()
    {
        return float.Parse(acLineLengthStr);
    }
}
