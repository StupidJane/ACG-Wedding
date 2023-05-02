using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    [Header("References")]
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
    }

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

}
