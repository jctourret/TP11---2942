using UnityEngine;

public class Enemy : MonoBehaviour,IHittable
{
  
   [SerializeField]private float _speed;
   public Transform _player;
   [SerializeField]private float _trackingRadius;
   private Vector2 _target;
   private Rigidbody2D _rb;
   private Vector2 _look;
   private Animator _animator;

   private void Awake()
   {
       _rb = GetComponent<Rigidbody2D>();
       _animator = GetComponent<Animator>();
       _look = gameObject.transform.up;
   }

   private void FixedUpdate()
   { 
       Follow();
       Move();
   }

   private void Follow()
   {
       float dist = Vector2.Distance(_player.position, transform.position);

       if (dist > _trackingRadius)
       {
           _target = Vector2.down.normalized;
         //  gameObject.transform.up = _look;// reemplaza al lookat
       }
       else
       {
           _target =_player.position.normalized;
          // gameObject.transform.up = _player.position - gameObject.transform.position;// reemplaza al lookat
       }
      
   }
   private void Move()
   {
       _rb.MovePosition(_rb.position+_target * (_speed * Time.fixedDeltaTime));
   }

   public void Damage()
   {
      _animator.SetBool("Death",true);
   }

   public void Death()
   {
       Destroy(gameObject);
   }

   private void OnDrawGizmos()
   {
       Gizmos.color=Color.yellow;
       Gizmos.DrawWireSphere(transform.position,_trackingRadius);
   }
}
