using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour,IHittable
{
    public static Action<int> onEnemyDeath;
    int _scoreValue = 50;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Damage()
    {
        _animator.SetBool("Death",true);
    }
    public void Death()
    {
        onEnemyDeath?.Invoke(_scoreValue);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHittable hit = collision.transform.GetComponent<IHittable>();
        if (hit != null)
        {
            hit.Damage();
        }
    }
}
