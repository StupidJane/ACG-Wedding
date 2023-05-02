using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    public Transform camTransform;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;

    //public GameObject parentObject;

    public float shootForce = 30f;
    public float timeCoolDown;

    public float destroyTime = 3f;

    bool readyToShoot = true;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && readyToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject loveArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation);
        loveArrow.transform.parent = arrowSpawnPoint.transform;

        Rigidbody rb = loveArrow.GetComponent<Rigidbody>();
        Vector3 shootingDir = camTransform.forward;
        
        rb.velocity = shootingDir * shootForce;

        // Start the shooting cooldown timer
        readyToShoot = false;
        Invoke("ResetShoot", timeCoolDown);
        Destroy(loveArrow, destroyTime);
    }
    private void ResetShoot()
    {
        readyToShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }
}
