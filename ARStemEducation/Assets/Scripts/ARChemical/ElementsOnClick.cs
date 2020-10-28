using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ElementsOnClick : MonoBehaviour, ITrackableEventHandler
{
    public GameObject h2oObj, waterElectObj, electFormula;
    public Button btn;
    public Text text;
    // object detection listener
    private TrackableBehaviour mTrackableBehaviour;
    Quaternion h2oObjInitRot;
    Quaternion waterElectObjInitRot;

    private void Start()
    {
        // btn.gameObject.SetActive(false);
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);
        text = btn.GetComponentInChildren<Text>();
        text.text = "Electrolysis";
        // init rotation
        h2oObjInitRot = h2oObj.transform.rotation;
        waterElectObjInitRot = waterElectObj.transform.rotation;

        // init listener
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnClick()
    {
        if (h2oObj.activeSelf == true)
        {
            h2oObj.transform.rotation = h2oObjInitRot;
            waterElectObj.transform.rotation = waterElectObjInitRot;
            ShowWaterElectObj();
        }
        else if (waterElectObj.activeSelf == true)
        {
            h2oObj.transform.rotation = h2oObjInitRot;
            waterElectObj.transform.rotation = waterElectObjInitRot;
            ShowH2OObj();
        }
    }
    // override listener function
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Show button when target is found
            btn.gameObject.SetActive(true);
            ShowH2OObj();
        }
        else
        {
            // Hidden button when target is lost
            // reset pos , rotation
            btn.gameObject.SetActive(false);
        }
    }

    private void ShowH2OObj()
    {
        h2oObj.SetActive(true);
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);
        text.text = "Electrolysis";
    }

    private void ShowWaterElectObj()
    {
        h2oObj.SetActive(false);
        waterElectObj.SetActive(true);
        electFormula.SetActive(true);
        text.text = "H2O";
    }
}