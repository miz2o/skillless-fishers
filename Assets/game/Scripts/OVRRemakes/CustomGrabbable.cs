using UnityEngine;

public class CustomGrabbable : OVRGrabbable
{
    public Transform handle;  // The specific grab point (handle transform)

    // Variable to store the offset between the hand and handle when grabbed
    private Vector3 grabOffset;


    public GameObject leftInfoMenu;
    public GameObject rightInfoMenu;
    public GameObject currentMenu;


    // Override GrabBegin method to handle the grab logic
    public override void GrabBegin(OVRGrabber hand, Collider grabPointy)
    {
        print("GrabBegin");

        if (grabPointy != null)
        {
            m_grabbedCollider = grabPointy;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = hand.gameObject.transform.position;
            transform.rotation = hand.gameObject.transform.rotation;
        }
        print("grabbing");
        if (gameObject.tag == "Fish")
        {
            print("Holding fish");
            if (leftInfoMenu && rightInfoMenu != null)
            {
                if(hand.gameObject.tag == "LeftHand")
                {
                    print("Left hand");
                    leftInfoMenu.SetActive(true);
                    currentMenu = leftInfoMenu;
                }
                else if (hand.gameObject.tag == "RightHand")
                {
                    print("Right hand");
                    rightInfoMenu.SetActive(true);
                    currentMenu = rightInfoMenu;
                }
                else
                {
                    print("Other tag");
                    return;
                }
                
            }
        }

    }
    
    
}
