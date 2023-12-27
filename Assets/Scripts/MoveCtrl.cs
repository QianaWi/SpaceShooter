using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public float FlySpeed;

    void Start()
    {
        Rigidbody rigbd = GetComponent<Rigidbody>();
        rigbd.velocity = transform.forward * FlySpeed;
    }
}
