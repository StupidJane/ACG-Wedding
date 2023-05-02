using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Transform Cam;

    public float range = 50f;

    void Start()
    {
        Cam = Camera.main.transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }
    }

    public void Interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(Cam.position, Cam.forward, out hit, range))
        {
            print(hit.collider.name);
            
        }
    }

}
