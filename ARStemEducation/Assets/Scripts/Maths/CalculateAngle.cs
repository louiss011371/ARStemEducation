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
    [SerializeField]
    private Image aImageAngle;
    [SerializeField]
    private Image bImageAngle;
    [SerializeField]
    private Image cImageAngle;
    private float lockAPointY, lockAPointZ, lockBPointX, lockBPointZ;
    [SerializeField]
    private GameObject storeLineLength;

    // Start is called before the first frame update
    void Start()
    {
        cImageAngle.transform.position = cPoint.position;
        lockAPointY = aPoint.transform.localPosition.y;
        lockAPointZ = aPoint.transform.localPosition.z;
        lockBPointX = bPoint.transform.localPosition.x;
        lockBPointZ = bPoint.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        float aPointXPosition = storeLineLength.GetComponent<StoreLineLength>().GetACLineLength();
        float bPointXPosition = storeLineLength.GetComponent<StoreLineLength>().GetBCLineLength();
        Vector3 lockAPosition = new Vector3(aPointXPosition, lockAPointY, lockAPointZ);
        Vector3 lockBPosition = new Vector3(lockBPointX, bPointXPosition, lockBPointZ);
        aPoint.transform.localPosition = lockAPosition;
        bPoint.transform.localPosition = lockBPosition;
        CalculateLineDist();
        aImageAngle.transform.position = aPoint.position;
        bImageAngle.transform.position = bPoint.position;
    }

    private void CalculateLineDist()
    {
        float abDist = Vector3.Distance(bPoint.transform.localPosition, aPoint.transform.localPosition);
        float acDist = Vector3.Distance(aPoint.transform.localPosition, cPoint.transform.localPosition);
        float bcDist = Vector3.Distance(bPoint.transform.localPosition, cPoint.transform.localPosition);

        Debug.Log("ab Dist " + abDist);
        Debug.Log("ac Dist  " + acDist);
        Debug.Log("bc Dist " + bcDist);
        LineDistDouble(abDist, acDist, bcDist);
        CalculateSinCosTan(abDist, acDist, bcDist);
    }

    private void CalculateSinCosTan(float abDistF, float acDistF, float bcDistF)
    {
        // sin cos tan formula
        float sinAValue = bcDistF / abDistF;
        float cosAValue = acDistF / abDistF;
        float tanAValue = bcDistF / acDistF;

        float sinBValue = acDistF / abDistF;
        float cosBValue = bcDistF / abDistF;
        float tanBValue = acDistF / bcDistF;

        // sinAngle = Sin-1(sinValue)
        float sinAAngle = Mathf.Rad2Deg * Mathf.Asin(sinAValue);
        float sinBAngle = Mathf.Rad2Deg * Mathf.Asin(sinBValue);
        // cosAngle = Cos-1(cosValue)
        float cosAAngle = Mathf.Rad2Deg * Mathf.Acos(cosAValue);
        float cosBAngle = Mathf.Rad2Deg * Mathf.Acos(cosBValue);
        // tanAngle = Tan-1(tanValue)
        float tanAAngle = Mathf.Rad2Deg * Mathf.Atan(tanAValue);
        float tanBAngle = Mathf.Rad2Deg * Mathf.Atan(tanBValue);

        // Round up sin/cos/tan value to 2d.p.
        RoundUpValueDouble(sinAValue, sinBValue, cosAValue, cosBValue, tanAValue, tanBValue);
        // Round up sin/cos/tan angle to int
        RoundUpAngle(sinAAngle, sinBAngle, cosAAngle, cosBAngle, tanAAngle, tanBAngle);
    }

    private int RoundUpAngleToInt(float angleF)
    {
        int angleInt = (int)Mathf.Round(angleF);
        return angleInt;
    }

    private double ConvertLineDistToOneDP(float distDouble)
    {
        // convert lineDist to 1d.p.
        double fDistToDouble = Mathf.Round(distDouble * 10f) / 10f;
        return fDistToDouble;
    }
    private double ConvertResultToTwoDP(float valueResult)
    {
        // convert result to 2d.p.
        double twoDPResult = Mathf.Round(valueResult * 100f) / 100f;
        return twoDPResult;
    }

    private void LineDistDouble(float abDistF, float acDistF, float bcDistF)
    {
        double abDistDouble = ConvertLineDistToOneDP(abDistF);
        double acDistDouble = ConvertLineDistToOneDP(acDistF);
        double bcDistDouble = ConvertLineDistToOneDP(bcDistF);

        DisplayLineDist(abDistDouble, acDistDouble, bcDistDouble);
    }

    private void RoundUpValueDouble(float sinAValue, float sinBValue, float cosAValue, float cosBValue, float tanAValue, float tanBValue)
    {
        // convert sin/cos/tan value to 2d.p.
        double twoDPSinAValue = ConvertResultToTwoDP(sinAValue);
        double twoDPCosAValue = ConvertResultToTwoDP(cosAValue);
        double twoDPTanAValue = ConvertResultToTwoDP(tanAValue);

        double twoDPSinBValue = ConvertResultToTwoDP(sinBValue);
        double twoDPCosBValue = ConvertResultToTwoDP(cosBValue);
        double twoDPTanBValue = ConvertResultToTwoDP(tanBValue);

        DisplayResult(twoDPSinAValue, twoDPSinBValue, twoDPCosAValue, twoDPCosBValue, twoDPTanAValue, twoDPTanBValue);
    }

    private void RoundUpAngle(float sinAAngle, float sinBAngle, float cosAAngle, float cosBAngle, float tanAAngle, float tanBAngle)
    {
        // round up angle to Int
        int roundUpSinAAngle = RoundUpAngleToInt(sinAAngle);
        int roundUpCosAAngle = RoundUpAngleToInt(cosAAngle);
        int roundUpTanAAngle = RoundUpAngleToInt(tanAAngle);

        int roundUpSinBAngle = RoundUpAngleToInt(sinBAngle);
        int roundUpCosBAngle = RoundUpAngleToInt(cosBAngle);
        int roundUpTanBAngle = RoundUpAngleToInt(tanBAngle);

        DisplayAngle(roundUpSinAAngle, roundUpSinBAngle, roundUpCosAAngle, roundUpCosBAngle, roundUpTanAAngle, roundUpTanBAngle);
    }
    private void DisplayAngle(int sinA, int sinB, int cosA, int cosB, int tanA, int tanB)
    {
        // Display value to UI
        sinAAngleText.text = "(" + sinA.ToString() + "°)";
        cosAAngleText.text = "(" + cosA.ToString() + "°)";
        tanAAngleText.text = "(" + tanA.ToString() + "°)";

        sinBAngleText.text = "(" + sinB.ToString() + "°)";
        cosBAngleText.text = "(" + cosB.ToString() + "°)";
        tanBAngleText.text = "(" + tanB.ToString() + "°)";

        float newAngleAFillAmountValue = (float)sinA / 360f;
        float newAngleBFillAmountValue = (float)sinB / 360f;

        aImageAngle.fillAmount = newAngleAFillAmountValue;
        bImageAngle.fillAmount = newAngleBFillAmountValue;
    }

    private void DisplayLineDist(double abDist, double acDist, double bcDist)
    {
        TextMesh abDistTextMesh = GameObject.Find("A To B Length").GetComponent<TextMesh>();
        TextMesh acDistTextMesh = GameObject.Find("A To C Length").GetComponent<TextMesh>();
        TextMesh bcDistTextMesh = GameObject.Find("B To C Length").GetComponent<TextMesh>();

        abDistTextMesh.text = abDist.ToString();
        acDistTextMesh.text = acDist.ToString();
        bcDistTextMesh.text = bcDist.ToString();
    }

    private void DisplayResult(double sinAResult, double sinBResult, double cosAResult, double cosBResult, double tanAResult, double tanBResult)
    { 
        sinAValueText.text = sinAResult.ToString();
        cosAValueText.text = cosAResult.ToString();
        tanAValueText.text = tanAResult.ToString();

        sinBValueText.text = sinBResult.ToString();
        cosBValueText.text = cosBResult.ToString();
        tanBValueText.text = tanBResult.ToString();
    }
}
