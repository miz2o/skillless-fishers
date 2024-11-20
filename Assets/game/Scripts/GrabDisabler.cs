using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDisabler : MonoBehaviour
{
private OVRGrabber myGrabber;
    public void destroyThis()
    {
        //this turns off the OVRGrabbable script
        this.GetComponent<OVRGrabbable>().enabled = false;
        //this gets the hand that's grabbing it
        myGrabber = this.GetComponent<OVRGrabbable>().m_grabbedBy;
        //use ForceRelease method in the OVRGrabber to release object
        myGrabber.ForceRelease(this.gameObject.GetComponent<OVRGrabbable>());
      
       
    }
}
