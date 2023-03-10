using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public int damage;          //当たった部位毎のダメージ量
    public GameObject attackedPerson;   //Bulletがあたったオブジェクト
    private HP hp;              //HPクラス

    void Start()
    {
        hp = attackedPerson.GetComponent<HP>();//PlayerまたはEnemyのHP情報を取得
    }

    void OnTriggerEnter(Collider other){

        //衝突判定時、オブジェクトのTagがshellの場合
        if (other.CompareTag("Shell")){

            //HPクラスのDamage関数を呼び出す
            hp.Damage(damage);

            //Bulletオブジェクトを破壊する.
            // Destroy(other.gameObject);
        }
    }
}