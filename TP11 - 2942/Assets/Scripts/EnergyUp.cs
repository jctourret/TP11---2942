using System;
using UnityEngine;

public class EnergyUp : MonoBehaviour
{
    public static Action energyUp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            energyUp?.Invoke();
        }
    }
}
