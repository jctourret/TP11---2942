using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class BombController : MonoBehaviour
{
    float _travelDistance = 5.0f;
    float _maxDistantce;
    float _speed = 5.0f;
    float _explosionRadius = 100;

    private void Start()
    {
        _maxDistantce = transform.position.y + _travelDistance;
    }
    private void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * _speed;
        if (transform.position.y >= _maxDistantce)
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position,_explosionRadius,LayerMask.GetMask("Enemys"));
            for(int i = 0; i < colls.Length; i++)
            {
                Renderer colRenderer = colls[i].GetComponent<Renderer>();
                IHittable hit = colls[i].GetComponent<IHittable>();
                if(hit != null && colRenderer.isVisible)
                {
                    hit.Damage();
                }
            }
            Destroy(this);
        }
    }
}
