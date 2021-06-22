using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyDeath : MonoBehaviour,IHittable
{
    public static Action onEnemyDeath;
    private Animator _animator;
    public GameObject _powerUpEnergy;
    public GameObject _powerUpBullet;
    
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
        RandPowerUp();
        onEnemyDeath?.Invoke();
        Destroy(gameObject);
    }

    private void RandPowerUp()
    {
        bool itemRand = Random.value > 0.5;
        Instantiate(itemRand ? _powerUpEnergy : _powerUpBullet, transform.position, transform.rotation);
    }
    
    
}
