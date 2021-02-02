using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] private Transform [] point;
    [SerializeField]
    private GameObject aToBLengthTextObj, bToCLengthTextObj, aToCLengthTextObj;
    [SerializeField]
    private GameObject aPoint, bPoint, cPoint;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.positionCount = point.Length;
        lr.SetPosition(0, point[0].position);
        lr.SetPosition(1, point[1].position);
        lr.SetPosition(2, point[2].position);

        aToBLengthTextObj.transform.position = Vector3.Lerp(aPoint.transform.position, bPoint.transform.position, 0.5f);
        bToCLengthTextObj.transform.position = Vector3.Lerp(bPoint.transform.position, cPoint.transform.position, 0.5f);
        aToCLengthTextObj.transform.position = Vector3.Lerp(aPoint.transform.position, cPoint.transform.position, 0.5f);

    }
}
