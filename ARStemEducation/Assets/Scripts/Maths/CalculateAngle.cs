using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAngle : MonoBehaviour
{
    [SerializeField]
    private Transform bPoint;
    [SerializeField]
    private Transform cPoint;

    [SerializeField]
    private Text tanAngleText, tanValueText;

    private float angle = 0;
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
        //Debug.Log("b point y = " + bPoint.transform.position.y);
        //Debug.Log("c point x = " + cPoint.transform.position.x);
        //Debug.Log("c point x = " + cPoint.transform.position.x);
        //(cPoint.transform.position.x - bPoint.transform.position.x);
        Debug.Log("bPoint.transform.position.y = " + bPoint.transform.localPosition);
        Debug.Log("cPoint.transform.position.x - transform.position.x = " + (cPoint.transform.localPosition.x - transform.localPosition.x));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = bPoint.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float roundUpAngle = (int)Mathf.Round(angle);
        tanAngleText.text = "(" + roundUpAngle.ToString() + "°)";
        float tanValue = bPoint.transform.localPosition.y / (cPoint.transform.localPosition.x - transform.localPosition.x);
        

        //double roundUpTanValue = (Mathf.Round(tanValue * 100)) / 100;
        tanValueText.text = tanValue.ToString();
        //Debug.Log("b point y = " + bPoint.transform.position.y);
        //tanValueText = 
        //direction = endPointTarget.position - transform.position;

        //sign = (direction.y >= 0) ? 1 : -1;
        //offset = (sign >= 0) ? 0 : 360;

        //angle = Vector3.Angle(Vector3.right, direction) * sign + offset;
        //angleText.text = angle.ToString();
    }
}
