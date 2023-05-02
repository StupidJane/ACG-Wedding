using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Transform Cam;

    public float range = 50f;

    public Material[] skybox;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (RenderSettings.skybox == skybox[0])
            {
                RenderSettings.skybox = skybox[1];
            }
            else
            {
                RenderSettings.skybox = skybox[0];
            }
            
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
