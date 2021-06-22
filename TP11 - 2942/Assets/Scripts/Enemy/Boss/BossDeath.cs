using System;
using UnityEngine;

public class BossDeath : MonoBehaviour, IHittable
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
        life--;
        if (life <= 0)
        {
        _animator.SetBool("Death",true);
        }
    }
    public void Death()
    {        
            onEnemyDeath?.Invoke();
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
