using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public GameObject[] Enemys;

    // 每生成一个敌人的间隔.
    public float SpwanWait;
    // 每一波敌人的数量.
    public int WaveCount;
    //每波敌人的间隔时间
    public float WaveWait;

    // 启动游戏后开始生成敌人的等待时间.
    public float StartWait;

    // UI相关
    private int scoreCount = 0;
    public Text ScoreText;
    public GameObject EndPanel;


    private bool isGameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        // 固定分辨率.
        Screen.SetResolution(540, 960, false);



        StartCoroutine(SpwanWaves());
    }



    // 随机生成敌人物体.
    IEnumerator SpwanWaves()
    {
        yield return new WaitForSeconds(StartWait);

        while (true)
        {
            for (int i = 0; i < WaveCount; ++i)
            {
                int index = Random.Range(0, Enemys.Length);
                GameObject go = Enemys[index];
                Vector3 pos = new Vector3(Random.Range(-5, 5), 0, 12);
                Quaternion rot = Quaternion.identity;
                Instantiate(go, pos, rot);
                yield return new WaitForSeconds(SpwanWait);
            }

            // 当主角死亡时，跳出出生逻辑.
            if (isGameOver)
            {
                break;
            }

            yield return new WaitForSeconds(WaveWait);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        scoreCount += value;
        ScoreText.text = "Score:" + scoreCount.ToString();
    }

    public void GameOver()
    {
        EndPanel.SetActive(true);
        isGameOver = true;
    }

    public void ReStartGame()
    {
        // 重新加载场景，重新开始新的一局游戏.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
