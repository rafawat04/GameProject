using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int HP;
    public int score;
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
        HP = player.GetComponent<HP>().hitPoint;      //HP情報を取得
        playerScoreText.text = "Player Score:"+score;
        playerHPText.text = "Player HP:"+HP;
        //Enemy
        HP = enemy.GetComponent<HP>().hitPoint;      //HP情報を取得
        enemyScoreText.text = "Enemy Score:"+score;
        enemyHPText.text = "Enemy HP :"+HP;
    }


}

