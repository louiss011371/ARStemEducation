using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAngle : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Text angleText;

    private float angle = 0;
    private Vector2 direction;

    private float sign = 1;
    private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;

        sign = (direction.y >= 0) ? 1 : -1;
        offset = (sign >= 0) ? 0 : 360;

        angle = Vector2.Angle(Vector2.right, direction) * sign + offset;
        angleText.text = angle.ToString();
    }
}
