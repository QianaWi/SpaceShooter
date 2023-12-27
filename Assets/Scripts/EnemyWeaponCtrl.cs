using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponCtrl : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShotPos;

    //射击间隔
    public float ShotSpace = 1;
    //射击等待时间.
    public float ShotWait = 1;

    private AudioSource shotAudio;

    void Start()
    {
        shotAudio = GetComponent<AudioSource>();

        // 重复执行一个方法.
        InvokeRepeating("EnemyShipFire", ShotWait, ShotSpace);
    }

    void EnemyShipFire()
    {
        Instantiate(Bullet, ShotPos.position, ShotPos.rotation);

        shotAudio.Play();
    }

}
