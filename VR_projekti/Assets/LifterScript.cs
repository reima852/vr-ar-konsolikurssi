using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifterScript : MonoBehaviour
{
    public int objectsOnLift;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        objectsOnLift= 0;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrabbableObject"))
        {
            objectsOnLift++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrabbableObject"))
        {
            objectsOnLift--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsOnLift > 1)
        {
            if (transform.position.y < 10)
            {
                rb.isKinematic = false;
                LiftUp();
            }
            else
            {
                rb.isKinematic = true;
            }
        }
        /*else if (objectsOnLift < 1)
        {
            if (transform.position.y > 0.2f)
            {
                rb.isKinematic = false;
                LiftDown();
            }
            else
            {
                rb.isKinematic = true;
            }
        }*/
    }

    private void LiftUp ()
    {
        if (rb.velocity.magnitude > 1.5)
        {
            rb.AddForce(Vector3.down * 1f);
        }
        else
        {
            rb.AddForce(Vector3.up * 4f);
        }

    }

    /*private void LiftDown()
    {
        

        if (rb.velocity.magnitude > 1.5)
        {
            rb.AddForce(Vector3.up * 1f);
        }
        else
        {
            rb.AddForce(Vector3.down * 4f);
        }
    }*/
}
