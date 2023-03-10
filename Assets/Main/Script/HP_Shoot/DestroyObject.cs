using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour {

    public int damage;//ダメージ量 インスペクターでHeadとBodyの数値をそれぞれ登録
    public GameObject attackedPerson;//Bulletがあたったオブジェクト
    private HP hp;//HPクラス
    private Image img;//赤くする画像

    void Start()
    {
        hp = attackedPerson.GetComponent<HP>();//PlayerまたはEnemyのHP情報を取得
        //画面を赤くするための準備
        GameObject flush = GameObject.Find("Flush");
        img = flush.GetComponent<Image>();
        img.color = Color.clear;
    }

    void Update()
    {
        //徐々に画面を透明にする
        img.color = Color.Lerp(img.color, Color.clear, Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){

        //衝突判定時、オブジェクトのTagがshellの場合
        if (other.CompareTag("Shell")){
            //HPクラスのDamage関数を呼び出す
            hp.Damage(damage);

            // Playerなら画面赤色
            if(attackedPerson.name=="FirstPerson")
            {
                img.color = new Color(0.4f, 0f, 0f, 0.4f);
            }
        }
    }
}