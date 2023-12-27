using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float ScrollerSpeed = 5;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Mathf.Repeat(ScrollerSpeed * Time.time, 30);
        transform.position = startPos + dis * -Vector3.forward;
    }
}
