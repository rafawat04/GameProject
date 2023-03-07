using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude;
    public float speed;

    void Start(){
        startPosition = transform.localPosition;
    }

    void Update(){
        float y = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(0,y+4,0);
    }
}
