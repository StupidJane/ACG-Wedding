using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    /*[Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject loveArrow;

    [Header("Settings")]
    public float shootingCD;

    [Header("Shooting")]
    public KeyCode shootingKey = KeyCode.Mouse0;
    public float shootingForce;
    public float shootingUpwardForce;

    bool readyToShoot;

    private void Start()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootingKey) && readyToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(loveArrow, attackPoint.position, cam.rotation);

        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * shootingForce + transform.up * shootingUpwardForce;

        arrowRb.AddForce(forceToAdd, ForceMode.Impulse);

        Invoke("ResetShoot", shootingCD);
    }
    private void ResetShoot()
    {
        readyToShoot = false;
    }*/

    /*public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 10f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        // Instantiate arrow object
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

        // Calculate arrow direction
        Vector3 arrowDirection = mainCamera.transform.forward + transform.forward;
        arrowDirection.Normalize();

        // Apply force to arrow
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.AddForce(arrowDirection * arrowSpeed, ForceMode.Impulse);
    }*/


    public Transform camTransform;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;  // the arrow prefab's game object

    public float shootForce = 30f;
    public float timeCoolDown;

    public float destroyTime = 3f;

    bool readyToShoot = true;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //GameObject loveArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation);
        GameObject loveArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.Euler(-90f, 0f, 0f));
        loveArrow.transform.parent = arrowSpawnPoint.transform;

        Rigidbody rb = loveArrow.GetComponent<Rigidbody>();
        Vector3 shootingDir = camTransform.forward;
        Quaternion arrowRotation = Quaternion.LookRotation(Vector3.up, shootingDir);
        loveArrow.transform.rotation = arrowRotation * Quaternion.Euler(0f, 0f, 0f);
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

    /*private void OnCollisionEnter(Collision collision)
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

        /*if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }*/
    //}
}
