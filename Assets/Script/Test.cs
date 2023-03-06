using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool b = true;
    private float elapsedTime;
    public float speed;
    void Start(){
        elapsedTime = Time.time;
    }
    void Update(){
        while(b){
            transform.position += transform.up * speed;
            if(elapsedTime == 2){
                speed = 0;
            }
        
        }
    }
    
}
