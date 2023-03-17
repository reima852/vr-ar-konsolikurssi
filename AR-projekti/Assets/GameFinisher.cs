using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    private bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameOver = true;
        }
    }

    private void OnGUI()
    {
        if (gameOver)
        {
            Debug.Log("It should be gg");

            GUILayout.Label("Game over, you won!");
        }
    }
}
