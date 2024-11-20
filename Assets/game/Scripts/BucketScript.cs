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

           if (collision.transform.GetComponent<GrabDisabler>())
           {
                collision.transform.GetComponent<GrabDisabler>().destroyThis();

           }



            Destroy(collision.gameObject);
            if (feedbackParticles != null)
            { 
              feedbackParticles.Play(); 
            }
        }
    }
}
