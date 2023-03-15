using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamageHandler : MonoBehaviour
{
    public void TakeDamage()
    {
        // Rotate the AI character by 180 degrees around the Y-axis
        transform.Rotate(0f, 180f, 0f);
    }
}
