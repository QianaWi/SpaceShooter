using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour
{
    // 爆炸特效
    public GameObject EnemyExplosion;
    public GameObject PlayerExplosion;

    // 物体被销毁时玩家获得的分数.
    public int ScoreValue;

    private GameMgr gameMgr;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameMgr");
        gameMgr = go.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (null != EnemyExplosion)
        {
            Instantiate(EnemyExplosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameMgr.GameOver();
        }

        // 增加UI分数.
        gameMgr.AddScore(ScoreValue);


        // 注意先后顺序.
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
