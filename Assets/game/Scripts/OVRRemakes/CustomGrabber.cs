using UnityEngine;

public class CustomGrabber : OVRGrabber
{
    [SerializeField]
    private Transform handleTransform; // Handle position for snapping

    // Track the object being grabbed
    protected override void GrabBegin()
    {
        base.GrabBegin(); // Call the base GrabBegin first to retain the core functionality

        if (m_grabbedObj != null && handleTransform != null)
        {
            // Adjust the grabbed object's position to the handle position
            Vector3 handlePosition = handleTransform.position;
            Quaternion handleRotation = handleTransform.rotation;

            // Apply the offset based on the difference between where we grabbed it and where the handle is
            m_grabbedObj.transform.position = handlePosition;
            m_grabbedObj.transform.rotation = handleRotation;

            // Optional: Adjust the grabbed object to the handle's position relative to the hand
            if (m_grabbedObj.grabbedRigidbody != null)
            {
                m_grabbedObj.grabbedRigidbody.MovePosition(handlePosition);
                m_grabbedObj.grabbedRigidbody.MoveRotation(handleRotation);
            }
        }
    }

    // Optionally, you can add custom release logic here.
    // Since GrabEnd() isn't overridable, we can manually handle release and cleanup.
    public void CustomRelease()
    {
        if (m_grabbedObj != null)
        {
            // Example of custom behavior when releasing an object
            Debug.Log("Custom Release Logic");

            // Reset the object's position/rotation or perform additional actions here

            // Finally, call GrabEnd() to release the object
            GrabEnd();  // Make sure to call the base GrabEnd() to properly handle the release
        }
    }
}
