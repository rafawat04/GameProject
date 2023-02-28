using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab; // 生成する壁のプレハブ
    public string[] spawnTags; // 壁を生成する位置のタグのリスト
    public int numWalls = 3; // 生成する壁の数

    void Start()
    {
        for (int i = 0; i < numWalls; i++)
        {
            // タグリストからランダムにタグを選択する
            string tag = spawnTags[Random.Range(0, spawnTags.Length)];

            // タグに一致するオブジェクトを取得する
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(tag);

            // 壁を生成する
            GameObject wall = Instantiate(wallPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            /*
            GameObject wall = Instantiate(wallPrefab, spawnPoint.transform.position, Quaternion.identity);
            */
            // 壁の大きさをランダムに決定する
            /*
            float scale = Random.Range(0.5f, 2f);
            wall.transform.localScale = new Vector3(scale, scale, scale);
            */
        }
    }
}


/*
{
    public GameObject wallPrefab; // 作成する壁のプレハブ
    public float wallWidth = 2f; // 壁の幅

    void Start()
    {
        // "WallSpawnPoint"タグを持つオブジェクトを検索する
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("wall1");

        // 壁を作成する
        GameObject wall = Instantiate(wallPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

    }
}
*/



