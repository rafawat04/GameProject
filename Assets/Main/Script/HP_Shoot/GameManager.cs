using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerHP;
    public int enemyHP;
    public int playerScore;
    public int enemyScore;
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
        //情報を取得
        playerHP= player.GetComponent<HP>().hitPoint;      
        playerScore= player.GetComponent<HP>().myScore;   
        enemyHP= enemy.GetComponent<HP>().hitPoint;    
        enemyScore= enemy.GetComponent<HP>().myScore;  

        //Player
        playerHPText.text = "Player HP:"+playerHP;
        //Scoreの加算
        if(playerHP==0)
        {
            enemyScore+=1;
        }
        enemyScoreText.text = "Enemy Score:"+enemyScore;
        //Enemy
        enemyHPText.text = "Enemy HP :"+enemyHP;
        //Scoreの加算
        if(enemyHP==0)
        {
            playerScore+=1;
        }
        playerScoreText.text = "Player Score:"+playerScore;
    }
}