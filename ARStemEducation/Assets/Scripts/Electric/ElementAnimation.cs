using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 initalPosition;
    private void Awake()
    {
        initalPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f); // third params is speed
    }

    private void OnDisable()
    {
        transform.position = initalPosition;
    }
}
