using UnityEngine;

public class CustomGrabbable : OVRGrabbable
{
    public Transform handle;  // The specific grab point (handle transform)

    // Variable to store the offset between the hand and handle when grabbed
    private Vector3 grabOffset;

    // Override GrabBegin method to handle the grab logic
    public override void GrabBegin(OVRGrabber hand, Collider grabPointy)
    { 

        if (grabPointy != null)
        {
            m_grabbedCollider = grabPointy;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = hand.gameObject.transform.position;
            transform.rotation = hand.gameObject.transform.rotation;
        } 

    }
}
