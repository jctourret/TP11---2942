using UnityEngine;

public class EnemyDeath : MonoBehaviour,IHittable
{
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
        Destroy(gameObject);
    }
    
}
