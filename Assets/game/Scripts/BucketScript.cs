using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    public string fishTag;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == fishTag)
        {
            print("Fish caught!");
            Destroy(collision.gameObject);
        }
    }
}
