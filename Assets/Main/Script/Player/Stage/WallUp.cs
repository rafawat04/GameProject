using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : MonoBehaviour
{
    public float speed;

    private float elapsedTime;
    
    void Start(){
        elapsedTime = Time.time;
    }
    void Update(){
        
        transform.position += transform.up * (speed/100);
        while(true){
            if(elapsedTime == 2f){
            this.speed = 0;
            }
        }
        
    }
}
