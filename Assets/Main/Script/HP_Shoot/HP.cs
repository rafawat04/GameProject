using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    public int hitPoint = 100;  //自分のHP
    public int myScore = 0;

    GameObject enemyObj;//アニメーション用
    GameObject enemy;//アニメーション用
    HP enemyHP;
    Animator animator;
    
	void Start() {
        enemy = GameObject.Find("Enemy");
        enemyObj = GameObject.Find("EnemyObj");
        animator = enemyObj.GetComponent<Animator> ();//アニメーション
        enemyHP = enemy.GetComponent<HP> ();//アニメーション
    }
    
    // Update is called once per frame
	void Update () {
	}

    //ダメージを受け取ってHPを減らす関数
    public void Damage(int damage)
    {
        //受け取ったダメージ分HPを減らす
        hitPoint -= damage;
        if(hitPoint <= 0)
        {
            hitPoint = 0;
            //EnemyのHPが0ならdeathのアニメーションを実行して消える
            if(enemyHP.hitPoint == 0)
            {
                animator.SetTrigger("death");
                Destroy(enemy, 5f);
            }
        }
    }
}