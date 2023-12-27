using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float XMin, XMax, ZMin, ZMax;
}

public class PlayerShipCtrl : MonoBehaviour
{
    public float Speed = 10;
    public float Tilt = 3; // 偏转量.

    public Boundary Bound;

    private Rigidbody rigbd;

    public GameObject Bullet;
    public Transform ShotPos;
    public float ShotSpace = 0.25f;//射击间隔
    private float nextShotTime;

    private AudioSource shotAudio;

    void Start()
    {
        rigbd = GetComponent<Rigidbody>();
        shotAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShotTime)
        {
            //创建子弹物体
            nextShotTime = Time.time + ShotSpace;
            Instantiate(Bullet, ShotPos.position, ShotPos.rotation);
            shotAudio.Play();

        }
    }

    private void FixedUpdate()
    {
        // 计算运动方向速度向量
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(h, 0, v);

        // 操作刚体速度产生运动
        rigbd.velocity = vec * Speed;

        // 产生偏转
        rigbd.rotation = Quaternion.Euler(0, 0, rigbd.velocity.x * (-1) * Tilt);

        // 限制边界
        float posX = Mathf.Clamp(rigbd.position.x, Bound.XMin, Bound.XMax);
        float posZ = Mathf.Clamp(rigbd.position.z, Bound.ZMin, Bound.ZMax);

        rigbd.position = new Vector3(posX, 0, posZ);


    }
}
