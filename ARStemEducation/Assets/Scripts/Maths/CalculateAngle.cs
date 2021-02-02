using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAngle : MonoBehaviour
{
    [SerializeField]
    private Transform aPoint;
    [SerializeField]
    private Transform bPoint;
    [SerializeField]
    private Transform cPoint;
    [SerializeField]
    private Text sinAngleText, sinValueText, tanAngleText, tanValueText;
    private TextMesh abDistText, acDistText, bcDistText;

    float abDist;
    float acDist;
    float bcDist;

    private float sinAngle = 0;
    private float tanAngle = 0;
    private Vector3 direction;

    private float sign = 1;
    private float offset = 0;
    private float aX, aY, bX, bY;
    private float lineDistanceEndToCenter = 0;
    private float lineDistanceStartToCenter = 0;
    private float lineDistanceStartToEnd = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bPoint.transform.position.y = " + bPoint.transform.localPosition);
        Debug.Log("cPoint.transform.position.x - transform.position.x = " + (cPoint.transform.localPosition.x - transform.localPosition.x));
        //abDist = Vector3.Distance(bPoint.transform.localPosition, aPoint.transform.localPosition);
        //acDist = Vector3.Distance(aPoint.transform.localPosition, cPoint.transform.localPosition);
        //bcDist = Vector3.Distance(bPoint.transform.localPosition, cPoint.transform.localPosition);
        //acDistTextObj.GetComponent<Text>().text = acDist.ToString();
        //bcDistTextObj.GetComponent<Text>().text = bcDist.ToString();

        TextMesh abDistTextMesh = GameObject.Find("A To B Length").GetComponent<TextMesh>();
        abDistTextMesh.text = "123";

    }

    // Update is called once per frame
    void Update()
    {
        abDist = Vector3.Distance(bPoint.transform.localPosition, aPoint.transform.localPosition);
        acDist = Vector3.Distance(aPoint.transform.localPosition, cPoint.transform.localPosition);
        bcDist = Vector3.Distance(bPoint.transform.localPosition, cPoint.transform.localPosition);

        TextMesh abDistTextMesh = GameObject.Find("A To B Length").GetComponent<TextMesh>();
        TextMesh acDistTextMesh = GameObject.Find("A To C Length").GetComponent<TextMesh>();
        TextMesh bcDistTextMesh = GameObject.Find("B To C Length").GetComponent<TextMesh>();

        // convert abDist to 1d.p.
        double abDistDouble = Mathf.Round(abDist * 10f) / 10f;
        double acDistDouble = Mathf.Round(acDist * 10f) / 10f;
        double bcDistDouble = Mathf.Round(bcDist * 10f) / 10f;

        abDistTextMesh.text = abDistDouble.ToString();
        acDistTextMesh.text = acDistDouble.ToString();
        bcDistTextMesh.text = bcDistDouble.ToString();

        // show this value to UI
        //Debug.Log("abDist = " + abDistDouble);

        Debug.Log("abDist = " + abDist + " acDist = " + acDist + " bcDist = " + bcDist);
        float sinValue = bcDist / abDist;
        float tanValue = bcDist / acDist;

        // sinAngle = Sin-1(sinValue)
        sinAngle = Mathf.Rad2Deg * Mathf.Asin(sinValue);
        // tanAngle = Tan-1(tanValue)
        tanAngle = Mathf.Rad2Deg * Mathf.Atan(tanValue);
        // round up angle to Int
        float roundUpSinAngle = (int)Mathf.Round(sinAngle);
        float roundUpTanAngle = (int)Mathf.Round(tanAngle);

        // Display value to UI
        sinAngleText.text = "(" + roundUpSinAngle.ToString() + "°)";
        tanAngleText.text = "(" + roundUpTanAngle.ToString() + "°)";

        // convert sin/cos/tan value to 2d.p.
        double twoDPSinValue = Mathf.Round(sinValue * 100f) / 100f;
        double twoDPTanValue = Mathf.Round(tanValue * 100f) / 100f;

        sinValueText.text = twoDPSinValue.ToString();
        tanValueText.text = twoDPTanValue.ToString();
    }
}
