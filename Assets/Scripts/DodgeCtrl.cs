using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCtrl : MonoBehaviour
{
    // 闪避的速度.
    public float DodgeMinSpeed;
    public float DodgeMaxSpeed;

    // 开始第一次闪避等待时间
    public float WaitMin;
    public float WaitMax;

    // 闪避时间.
    public float DodgeMinTime;
    public float DodgeMaxTime;


    // 闪避加速度
    public float AccelerSpeed;

    // 随机闪避目标速度
    private float dodgeTagSpeed;

    private Rigidbody rigbd;

    public float Tilt = 3; // 偏转量.
    public Boundary Bound;



    // Start is called before the first frame update
    void Start()
    {
        rigbd = GetComponent<Rigidbody>();

        StartCoroutine(CalcDodgeSpeed());
    }

    IEnumerator CalcDodgeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(WaitMin, WaitMax));

            dodgeTagSpeed = Random.Range(DodgeMinSpeed, DodgeMaxSpeed);

            if (transform.position.x > 0)
            {
                // 敌人飞船在右边，往左闪避.
                dodgeTagSpeed = -dodgeTagSpeed;
            }
            yield return new WaitForSeconds(Random.Range(DodgeMinTime, DodgeMaxTime));
            dodgeTagSpeed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 通过加速度产生的渐变速度，让飞船飞行变得不生硬
        float dodgeVal = Mathf.MoveTowards(rigbd.velocity.x, dodgeTagSpeed, Time.deltaTime * AccelerSpeed);

        rigbd.velocity = new Vector3(dodgeVal, 0, rigbd.velocity.z);


        // 产生偏转
        rigbd.rotation = Quaternion.Euler(0, 0, rigbd.velocity.x * (-1) * Tilt);

        // 限制边界
        float posX = Mathf.Clamp(rigbd.position.x, Bound.XMin, Bound.XMax);
        float posZ = Mathf.Clamp(rigbd.position.z, Bound.ZMin, Bound.ZMax);

        rigbd.position = new Vector3(posX, 0, posZ);
    }
}
