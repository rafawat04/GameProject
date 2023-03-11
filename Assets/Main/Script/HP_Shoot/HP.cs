using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    public int hitPoint = 100;  //自分のHP
    public int myScore = 0;
    
	void Start() {
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
        }
    }
}