using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public string fishTag;
    public ParticleSystem feedbackParticles;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == fishTag)
        {
            print("Fish caught!");

            if (collision.gameObject.GetComponent<OVRGrabbable>() != null)
            {
                Destroy(collision.gameObject.GetComponent<OVRGrabbable>());
            }
            else if (collision.gameObject.GetComponent<CustomGrabbable>() != null)
            {
                Destroy(collision.gameObject.GetComponent<CustomGrabbable>());
            }

                Destroy(collision.gameObject);
            if (feedbackParticles != null)
            { 
              feedbackParticles.Play(); 
            }
        }
    }
}
