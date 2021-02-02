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
        Debug.Log("bPoint.transform.position.y = " + bPoint.transform.localPosition);
        Debug.Log("cPoint.transform.position.x - transform.position.x = " + (cPoint.transform.localPosition.x - transform.localPosition.x));
    }

    // Update is called once per frame
    void Update()
    {
        float tanValue = bPoint.transform.localPosition.y / (cPoint.transform.localPosition.x - transform.localPosition.x);

        angle = Mathf.Rad2Deg * Mathf.Atan(tanValue);
        float roundUpAngle = (int)Mathf.Round(angle);
        tanAngleText.text = "(" + roundUpAngle.ToString() + "°)";
        tanValueText.text = tanValue.ToString();
    }
}
