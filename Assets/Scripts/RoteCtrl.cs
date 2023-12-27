using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteCtrl : MonoBehaviour
{
    public float RoteSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigbd = GetComponent<Rigidbody>();
        rigbd.angularVelocity = Random.insideUnitSphere * RoteSpeed;
    }
}
