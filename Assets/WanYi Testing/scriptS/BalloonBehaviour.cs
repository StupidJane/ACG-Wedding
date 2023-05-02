using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBehaviour : MonoBehaviour
{
    public BalloonSpawning balloonSpawning; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
            balloonSpawning.BalloonDestroyed(gameObject);
        }
    }
}
