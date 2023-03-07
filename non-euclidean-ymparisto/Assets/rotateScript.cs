using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    public Transform cubeTransform;
    public float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cubeTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (elapsedTime < 360)
        {
            elapsedTime += Time.deltaTime * 45;
        }
        else
        {
            elapsedTime = 0;
        }

        cubeTransform.rotation = Quaternion.Euler(cubeTransform.rotation.x, elapsedTime, cubeTransform.rotation.z);
    }
}
