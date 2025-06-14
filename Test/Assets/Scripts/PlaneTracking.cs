using System.Collections;
using System.Collections.Generic;
using Rokid.UXR.Module;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneTracking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startTracking()
    {
        Rokid.UXR.Module.ARPlaneManager.Instance.OpenPlaneTracker();
    }
    public void stopTracking()
    {
        Rokid.UXR.Module.ARPlaneManager.Instance.ClosePlaneTracker();
    }
}
