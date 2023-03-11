using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int HP;
    public int Score;
    public Text playerScoreText;
    public Text enemyScoreText;
    public Text playerHPText;
    public Text enemyHPText;
    
    public GameObject player;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPerson");   //Player情報を取得
        enemy = GameObject.Find("Enemy");   //敵情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Player
        HP= player.GetComponent<HP>().hitPoint;      //HP情報を取得
        Score= player.GetComponent<HP>().myScore;      //Score情報を取得
        playerHPText.text = "Player HP:"+HP;
        //Scoreの加算
        if(HP==0)
        {
            Score+=1;
        }
        playerScoreText.text = "Player Score:"+Score;
        //Enemy
        HP= enemy.GetComponent<HP>().hitPoint;      //HP情報を取得
        Score= enemy.GetComponent<HP>().myScore;      //Score情報を取得
        enemyHPText.text = "Enemy HP :"+HP;
        //Scoreの加算
        if(HP==0)
        {
            Score+=1;
        }
        enemyScoreText.text = "Enemy Score:"+Score;
    }
}

