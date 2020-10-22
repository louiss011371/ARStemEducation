using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricElementsMove : MonoBehaviour
{
    //public GameObject element;
    //public GameObject element1;
    GameObject[] elementObj;
    // Start is called before the first frame update
    void Start()
    {

        //elementObj = element.gameObject.transform.GetChild(0).gameObject;
        elementObj = GameObject.FindGameObjectsWithTag("electricElements");
 
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        //Debug.Log("z" + obj.transform.position.z);
        //Debug.Log("x" + obj.transform.position.x);
        foreach (GameObject obj in elementObj)
        {
            if (obj.transform.position.x < 5 && obj.transform.position.z > -0.1)
            {
                obj.transform.position += new Vector3(0.03f, 0f, 0f);
            }
            if (obj.transform.position.x > 5 && obj.transform.position.z > -3.9)
            {
                obj.transform.position += new Vector3(0f, 0f, -0.03f);
            }
            if (obj.transform.position.z < -3.9)
            {
                obj.transform.position += new Vector3(-0.03f, 0f, 0f);
            }
            if (obj.transform.position.x < -3)
            {
                obj.transform.position += new Vector3(0f, 0f, 0.03f);

            }
        }
    }
}
