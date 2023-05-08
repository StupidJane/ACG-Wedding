using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public GameObject destroyParticleEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            Instantiate(destroyParticleEffect, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            BalloonSpawning spawner = FindObjectOfType<BalloonSpawning>();
            spawner.BalloonDestroyed(gameObject);
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Balloon" )
        {
            Destroy(this.gameObject);
        }
    }
}
