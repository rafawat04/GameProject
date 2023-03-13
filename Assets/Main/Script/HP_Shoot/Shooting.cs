using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public AudioSource gunMachine;
    public GameObject bulletPrefab;
    public float shotSpeed = 1500;//銃弾の速さ
    public int shotCount = 30;//1回に入れられる銃弾の数
    private float shotInterval;

    //発砲時の火花エフェクト用
    public ParticleSystem ps;
    GameObject gunEffect;

    private bool isFiring = false;

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
    if (Input.GetMouseButton(0))
    {
        shotInterval -= Time.deltaTime;

        if (shotInterval <= 0 && shotCount > 0)
        {
            shotCount -= 1;

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x-90, transform.parent.eulerAngles.y,0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * shotSpeed);
            gunMachine.Play();
            //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
            // Destroy(bullet, 0.5f);

            //火花エフェクトの再生
            gunEffect.SetActive(true);
            ps.Play();

            // Set the time interval between shots to 0.1 seconds
            shotInterval = 0.1f;
        }
        else
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

    void FireShot()
    {
        shotCount -= 1;

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x - 90, transform.parent.eulerAngles.y, 0));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * shotSpeed);
        gunMachine.Play();
        //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
        // Destroy(bullet, 0.5f);
        
        //火花エフェクトの再生
        gunEffect.SetActive(true);
        ps.Play();
    }

    //「Rキー」で銃弾セット
    void OnGUI()
    {
        // Set the color of the button based on the value of shotCount
        Color buttonColor = (shotCount > 0) ? Color.white : Color.red;
        GUI.backgroundColor = buttonColor;
        
        // Create a label to display the remaining shots
        GUI.Label(new Rect(140, 20, 80, 40), "Shots: " + shotCount);

        if (GUI.Button(new Rect(20, 20, 100, 40), "Reload"))
        {
            shotCount = 30;
        }
    }
}
