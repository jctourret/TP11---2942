using System;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public static Action onEnemyDeath;
    private Animator _animator;
    [SerializeField]private float life;
    
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
        life--;
        if (life <= 0)
        {
            onEnemyDeath?.Invoke();
            Destroy(gameObject);
        }
    }

}
