using UnityEngine;

public class CustomGrabbable : OVRGrabbable
{
    public Transform handle;  // The specific grab point (handle transform)
    private Vector3 grabOffset;  // Offset from hand to handle

    // Override GrabBegin method to ensure grabbing at the handle
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        // Check if the handle exists
        if (handle != null)
        {
            // Calculate the offset between the handle and the hand position
            grabOffset = handle.position - hand.transform.position;

            // Manually set the position of the object to the handle's position
            transform.position = handle.position;

            // Lock the object's position relative to the hand by setting its Rigidbody to kinematic
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;  // Prevent physics interaction during the grab
            }
        }
    }

    // Override GrabEnd to return the object back to physics control
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Restore physics behavior
            rb.velocity = linearVelocity;
            rb.angularVelocity = angularVelocity;
        }

        base.GrabEnd(linearVelocity, angularVelocity);
    }

    // Update the position of the object every frame while it's being grabbed
    void Update()
    {
        if (isGrabbed && handle != null)
        {
            // Re-align the object with the handle position to ensure it's always at the correct grab location
            OVRGrabber grabber = grabbedBy;
            if (grabber != null)
            {
                // Set the position of the object to always match the handle's position
                transform.position = handle.position;
                // Optionally, you can also adjust rotation to align the object with the handle
                transform.rotation = handle.rotation;
            }
        }
    }
}
