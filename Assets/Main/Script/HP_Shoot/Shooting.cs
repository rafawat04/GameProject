using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shotSpeed = 1500;//銃弾の速さ
    public int shotCount = 30;//1回に入れられる銃弾の数
    private float shotInterval;

    //発砲時の火花エフェクト用
    public ParticleSystem ps;
    GameObject gunEffect;

    private void Start()
    {
        //火花エフェクトの設定
        gunEffect = GameObject.Find("GunEffect");
        //GetComponentInChildrenで取得して変数psでパーティクルシステムを参照
        ps = GetComponentInChildren<ParticleSystem>();
        //Inspectorで設定したオブジェクトを非表示
        gunEffect.SetActive(false);
        //パーティクルシステムをストップ
        ps.Stop();
    }

    void Update()
    {
        //「Mキー」で銃弾発射
        if (Input.GetKey(KeyCode.M))
        {
            shotInterval += 1;

            if (shotInterval % 5 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x-90, transform.parent.eulerAngles.y,0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                Destroy(bullet, 3.0f);

                //火花エフェクトの再生
                gunEffect.SetActive(true);
                ps.Play();
            }else
            {
                gunEffect.SetActive(false);
                //パーティクルシステムをストップ
                ps.Stop();
            }
        }

        //「Rキー」で銃弾セット
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
        }
    }
}