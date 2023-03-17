using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Vuforia;

public class DealWithMouseInput : MonoBehaviour
{
    private Transform clickedObject = null;
    private Vector3 lastPlanePoint;
    public GameObject objectToInstantiate;

    // Update is called once per frame
    void Update()
    {
        Plane targetPlane = new Plane(transform.up, transform.position);

        // Tehd‰‰n raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Et‰isyys objektiin
        float dist = 0.0f;

        targetPlane.Raycast(ray, out dist);

        // ruudun piste, jolta objektiin osuttiin.
        Vector3 planePoint = ray.GetPoint(dist);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, 1000))
        {

            clickedObject = hit.transform;
            lastPlanePoint = planePoint;
        }
        else
        {
            clickedObject = null;
            lastPlanePoint = Vector3.zero;
        }

        if (clickedObject != null)
        {
            if (hit.collider.CompareTag("Object"))
            {
                GameObject collidedObject = hit.collider.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Left clicked on an object, color should be changing");
                    Material material = collidedObject.GetComponent<Renderer>().material;
                    material.color = (material.color == Color.red) ? Color.green : Color.red;
                }
                if (Input.GetMouseButtonDown(1))
                {

                    Debug.Log("Right clicked on an object, which should start moving");
                    clickedObject.position += planePoint - lastPlanePoint;
                    lastPlanePoint = planePoint;
                }

                if (Input.GetMouseButtonDown(2))
                {
                    //Luodaan uusi objekti tasolle

                    Debug.Log("Middle clicked on a plane, which should spawn a prefab");
                    Instantiate(objectToInstantiate, clickedObject.parent, instantiateInWorldSpace: false);
                }
            }
        }            
    }
}

