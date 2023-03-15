using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject mainCamera;
    public GameObject subCamera;
    public GameObject clearLogo;
    public GameObject gameOverLogo;
    public GameObject restartButton;
    public GameObject exitButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPerson");   //Player情報を取得
        enemy = GameObject.Find("Enemy");   //敵情報を取得
        clearLogo.SetActive(false);//結果表示のための画像を非表示にする
        gameOverLogo.SetActive(false);//結果表示のための画像を非表示にする
        restartButton.SetActive(false);//結果表示のための画像を非表示にする
        exitButton.SetActive(false);//結果表示のための画像を非表示にする
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

      
        if(playerScore>=1 || enemyScore>=1){
            //マウスポインターのロックを解除
            Cursor.lockState = CursorLockMode.None;
            //サブカメラをアクティブに設定
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            //結果表示
            if(playerScore>=1)
            {
                clearLogo.SetActive(true);
            }else
            {
                gameOverLogo.SetActive(true);
            }
            restartButton.SetActive(true);
            exitButton.SetActive(true);

        }
        else{
            //メインカメラをアクティブに設定
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
}
