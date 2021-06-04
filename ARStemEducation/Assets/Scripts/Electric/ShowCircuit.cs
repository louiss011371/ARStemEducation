using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class ShowCircuit : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Button btn;
    public GameObject switchBar;
    // Start is called before the first frame update
    void Start()
    {
        btn.gameObject.SetActive(false);
        // init listener
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Show button when target is found
            btn.gameObject.SetActive(true);
        }
        else
        {
            btn.gameObject.SetActive(false);
            switchBar.GetComponent<SwitchBar>().StatusOff();
            // stop electric element move
        }
    }
}
