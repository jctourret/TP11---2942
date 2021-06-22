using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScaleUp : MonoBehaviour
{
    public static Action<float> bulletScaleUp;
    float scaleBuff = 0.1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            bulletScaleUp?.Invoke(scaleBuff);
        }
    }
}
