using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class WallGenerator : MonoBehaviour
{   
    public GameObject wallPrefab; // 生成する壁のプレハブ
    public string[] spawnTags; // 壁を生成する位置のタグのリスト
    public int numWalls = 4; // 生成する壁の数

    // public NavMesh navMesh;

    // public void RecalculateNavMesh()
    // {
    //     NavMeshBuilder.BuildNavMesh(navMesh.navMeshData, navMesh.GetBuildSettings());
    // }
    
    void Start()
    {
        int[] all = new int[] {0, 1, 2, 3, 4, 5};
        int[] selectedNum = new int[numWalls];
        
        for (int i = 0; i < numWalls; i++)
        {
            // タグリストからランダムにタグを選択する
            selectedNum[i] = Random.Range(0, spawnTags.Length);
            string stringTag = spawnTags[selectedNum[i]];

            // タグに一致するオブジェクトを取得する
            GameObject spawnPoint = GameObject.FindGameObjectWithTag(stringTag);

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
            // Add the NavMeshObstacle component to the wall object
            // NavMeshObstacle navMeshObstacle = wall.AddComponent<NavMeshObstacle>();
            // navMeshObstacle.carving = true;
        }
       
        //差集合を配列に変換
        int[] resultArray = all.Except(selectedNum).ToArray();

        for (int i = 0; i < resultArray.Length; i++)
        {
            string deleteTag = spawnTags[resultArray[i]];
            GameObject deleteWall = GameObject.FindGameObjectWithTag(deleteTag);
            deleteWall.SetActive(false);
        }
    }


    //もとの内容
    // void Start()
    // {
    //     for (int i = 0; i < numWalls; i++)
    //     {
    //         // タグリストからランダムにタグを選択する
    //         string tag = spawnTags[Random.Range(0, spawnTags.Length)];

    //         // タグに一致するオブジェクトを取得する
    //         GameObject spawnPoint = GameObject.FindGameObjectWithTag(tag);

    //         // 壁を生成する
    // //         GameObject wall = Instantiate(wallPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    //         /*
    //         GameObject wall = Instantiate(wallPrefab, spawnPoint.transform.position, Quaternion.identity);
    //         */
    //         // 壁の大きさをランダムに決定する
    //         /*
    //         float scale = Random.Range(0.5f, 2f);
    //         wall.transform.localScale = new Vector3(scale, scale, scale);
    //         */
    //         // Add the NavMeshObstacle component to the wall object
    //         // NavMeshObstacle navMeshObstacle = wall.AddComponent<NavMeshObstacle>();
    //         // navMeshObstacle.carving = true;
    //     }
    // }
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



