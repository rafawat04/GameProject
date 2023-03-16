using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shotSpeed = 1500;//銃弾の速さ
    public int shotCount = 30;//1回に入れられる銃弾の数
    private float shotInterval;
    public GameObject enemy;
    // private HP enemyHP;

    public enum TargetLocation{PlayerBody, PlayerHead}

    //発砲時の火花エフェクト用
    public ParticleSystem ps;
    GameObject gunEffect;

    private void Start()
    {
        //火花エフェクトの設定
        gunEffect = GameObject.Find("EnemyGunEffect");
        //GetComponentInChildrenで取得して変数psでパーティクルシステムを参照
        ps = GetComponentInChildren<ParticleSystem>();
        //Inspectorで設定したオブジェクトを非表示
        gunEffect.SetActive(false);
        //パーティクルシステムをストップ
        ps.Stop();
        // enemyHP = parent.GetComponent<HP>();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        if(shotCount == 0)
        {
            shotCount = 30;
        }
    }

    public void Shoot(TargetLocation targetLocation)
    {
        if (enemy != null )
        {
            shotInterval += 1;

            if (shotInterval % 50 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x-90, transform.parent.eulerAngles.y,0));

                if(targetLocation == TargetLocation.PlayerHead)
                {
                    //一時的に変更
                    bullet.transform.Rotate(-10f,0f,0f);//Bulletの見た目の角度調整
                    transform.Rotate(0f,0f,0f);//Bulletの進む向きの調整
                }
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                //Destroy(bullet, 0.5f);

                //火花エフェクトの再生
                gunEffect.SetActive(true);
                ps.Play();
            }else
            {
                gunEffect.SetActive(false);
                //パーティクルシステムをストップ
                ps.Stop();
            }

            //銃弾セット
            if(shotCount == 0){
                StartCoroutine(Reload());
            }
        }
    }
}
