using UnityEngine;
using System.Collections;

public class LRTesting : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LRLineController line;

    // Use this for initialization
    void Start()
    {
        line.SetUpLine(points);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
