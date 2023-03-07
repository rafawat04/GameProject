using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int HP;
    public Text HPText;
    public int score;
    public Text scoreText;
    
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");   //敵情報を取得
    }

    // Update is called once per frame
    void Update()
    {
        HP = enemy.GetComponent<HP>().hitPoint;      //HP情報を取得
        scoreText.text = "Score:"+score;
        HPText.text = "HP:"+HP;
    }


}

