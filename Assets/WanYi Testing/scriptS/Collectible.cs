using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("SpinOBJ")]
    public float spinSpeed = 3.0f;

    [Header("Movement")]
    public GameObject collectibleItem;
    public float itemMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.Rotate(0, spinSpeed, 0);
    }
}
