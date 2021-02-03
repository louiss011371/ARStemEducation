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
    private Text sinAAngleText, sinAValueText, cosAAngleText, cosAValueText, tanAAngleText, tanAValueText;
    [SerializeField]
    private Text sinBAngleText, sinBValueText, cosBAngleText, cosBValueText, tanBAngleText, tanBValueText;

    float abDist;
    float acDist;
    float bcDist;

    private float sinAAngle = 0;
    private float cosAAngle = 0;
    private float tanAAngle = 0;

    private float sinBAngle = 0;
    private float cosBAngle = 0;
    private float tanBAngle = 0;

    // Start is called before the first frame update
    void Start()
    {

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
        // sin cos tan formula
        float sinAValue = bcDist / abDist;
        float cosAValue = acDist / abDist;
        float tanAValue = bcDist / acDist;

        float sinBValue = acDist / abDist;
        float cosBValue = bcDist / abDist;
        float tanBValue = acDist / bcDist;

        // sinAngle = Sin-1(sinValue)
        sinAAngle = Mathf.Rad2Deg * Mathf.Asin(sinAValue);
        sinBAngle = Mathf.Rad2Deg * Mathf.Asin(sinBValue);
        // cosAngle = Cos-1(cosValue)
        cosAAngle = Mathf.Rad2Deg * Mathf.Acos(cosAValue);
        cosBAngle = Mathf.Rad2Deg * Mathf.Acos(cosBValue);
        // tanAngle = Tan-1(tanValue)
        tanAAngle = Mathf.Rad2Deg * Mathf.Atan(tanAValue);
        tanBAngle = Mathf.Rad2Deg * Mathf.Atan(tanBValue);
        // round up angle to Int
        float roundUpSinAAngle = (int)Mathf.Round(sinAAngle);
        float roundUpCosAAngle = (int)Mathf.Round(cosAAngle);
        float roundUpTanAAngle = (int)Mathf.Round(tanAAngle);

        float roundUpSinBAngle = (int)Mathf.Round(sinBAngle);
        float roundUpCosBAngle = (int)Mathf.Round(cosBAngle);
        float roundUpTanBAngle = (int)Mathf.Round(tanBAngle);

        // Display value to UI
        sinAAngleText.text = "(" + roundUpSinAAngle.ToString() + "°)";
        cosAAngleText.text = "(" + roundUpCosAAngle.ToString() + "°)";
        tanAAngleText.text = "(" + roundUpTanAAngle.ToString() + "°)";

        sinBAngleText.text = "(" + roundUpSinBAngle.ToString() + "°)";
        cosBAngleText.text = "(" + roundUpCosBAngle.ToString() + "°)";
        tanBAngleText.text = "(" + roundUpTanBAngle.ToString() + "°)";

        // convert sin/cos/tan value to 2d.p.
        double twoDPSinAValue = Mathf.Round(sinAValue * 100f) / 100f;
        double twoDPCosAValue = Mathf.Round(cosAValue * 100f) / 100f;
        double twoDPTanAValue = Mathf.Round(tanAValue * 100f) / 100f;

        double twoDPSinBValue = Mathf.Round(sinBValue * 100f) / 100f;
        double twoDPCosBValue = Mathf.Round(cosBValue * 100f) / 100f;
        double twoDPTanBValue = Mathf.Round(tanBValue * 100f) / 100f;

        sinAValueText.text = twoDPSinAValue.ToString();
        cosAValueText.text = twoDPCosAValue.ToString();
        tanAValueText.text = twoDPTanAValue.ToString();

        sinBValueText.text = twoDPSinBValue.ToString();
        cosBValueText.text = twoDPCosBValue.ToString();
        tanBValueText.text = twoDPTanBValue.ToString();
    }
}
