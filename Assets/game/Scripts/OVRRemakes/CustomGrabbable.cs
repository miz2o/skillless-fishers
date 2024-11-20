using System;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class CustomGrabbable : OVRGrabbable
{
    public Transform handle;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        // Check if a handle is assigned
        if (handle != null)
        {
            // Align the handle's position with the hand's position
            Vector3 grabOffset = handle.position - hand.transform.position;

            // Adjust the position of the object so it's grabbed at the handle
            transform.position = handle.position;
            transform.rotation = handle.rotation; // Optionally align rotation

            // Update the grab point and the root to the handle
            m_grabbedCollider = grabPoint; // This ensures we grab the object at the specific point
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        // No additional logic needed here unless you want to modify how the object behaves after release
    }

}
