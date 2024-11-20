using System.Collections; // Make sure this line is included at the top
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public string fishTag;
    public ParticleSystem feedbackParticles;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is a fish
        if (collision.gameObject.tag == fishTag)
        {
            print("Fish caught!");

            // Check if the fish object is still valid
            if (collision.gameObject != null)
            {
                // Disable the collider before destroying the fish
                Collider fishCollider = collision.gameObject.GetComponent<Collider>();
                if (fishCollider != null)
                {
                    fishCollider.enabled = false; // Disable collider
                }

                // Optionally, disable the grabbable component (in case it's still interacting with OVR)
                OVRGrabbable grabbable = collision.gameObject.GetComponent<OVRGrabbable>();
                if (grabbable != null)
                {
                    grabbable.enabled = false; // Disable grabbable component
                }

                CustomGrabbable customGrabbable = collision.gameObject.GetComponent<CustomGrabbable>();
                if (customGrabbable != null)
                {
                    customGrabbable.enabled = false; // Disable custom grabbable component
                }

                // Delay destruction to give Unity a chance to clean up physics interactions
                StartCoroutine(DestroyFish(collision.gameObject));

                // Play feedback particles
                if (feedbackParticles != null)
                {
                    feedbackParticles.Play();
                }
            }
        }
    }

    private IEnumerator DestroyFish(GameObject fish)
    {
        // Wait for one frame before destroying, allowing physics interactions to settle
        yield return new WaitForEndOfFrame();

        // After waiting, destroy the fish object
        if (fish != null)
        {
            fish.SetActive(false);

        }
    }
}
