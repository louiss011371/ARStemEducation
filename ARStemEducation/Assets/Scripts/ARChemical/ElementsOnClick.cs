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

    private void Start()
    {
        // btn.gameObject.SetActive(false);
        waterElectObj.SetActive(false);
        electFormula.SetActive(false);
        text = btn.GetComponentInChildren<Text>();

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
            ResetRotation();
            ShowWaterElectObj();
        }
        else if (waterElectObj.activeSelf == true)
        {
            ResetRotation();
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
            ResetRotation();
            ShowH2OObj();
        }
        else
        {
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

    private void ResetRotation()
    {
        h2oObj.transform.rotation = new Quaternion(0, 0, 0, 0);
        waterElectObj.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}