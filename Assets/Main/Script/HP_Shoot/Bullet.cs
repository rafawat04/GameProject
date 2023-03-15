using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //空撃ちの時
        Destroy(gameObject,0.5f);
    }

    void OnTriggerEnter(Collider other){
            // 人や壁など何かに当たったとき
            Destroy(gameObject);
    }
}
