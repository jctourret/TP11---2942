using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour,IHittable
{
    public static Action onEnemyDeath;
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
        onEnemyDeath?.Invoke();
        Destroy(gameObject);
    }
}
