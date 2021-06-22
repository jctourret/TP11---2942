using UnityEngine;

public class Bullet : MonoBehaviour,IHittable
{
    private Rigidbody2D _rb;
    [SerializeField]private float _speed;
    private Animator _animator;
    private BoxCollider2D _collider;
   [SerializeField] private float timeToDestroy;
   private bool collision;
   private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
       Move();
       Destroy(gameObject,timeToDestroy);
    }
    
    private void Move()
    {  if(!collision)
        _rb.MovePosition(_rb.position + Vector2.down.normalized* (_speed * Time.deltaTime));
    }
    
    public void Damage()
    {
        collision = true;
        _animator.SetBool("Death",true);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
    
}
