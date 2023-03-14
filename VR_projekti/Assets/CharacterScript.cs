using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Collider collider1;
    public bool gameWon, onLift;
    private float cooldown = 0f;

    private void Start()
    {
        cooldown = 0;
        onLift = false;
        gameWon = false;
        collider1 = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrabbableObject"))
        {
            Physics.IgnoreCollision(collision.collider, collider1);
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            gameWon = true;
        }

        else if (collision.gameObject.CompareTag("Lift"))
        {
            if (!onLift)
            {
                transform.position = transform.position + Vector3.up * 0.2f;
                onLift = true;
                cooldown = 0.5f;
            }
        }
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lift"))
        {
            if (cooldown < 0)
            {
                onLift = false;
            }
        }
    }

    private void OnGUI()
    {
        if (gameWon)
        {
            GUILayout.Label("You won the game!");
        }
    }
}

