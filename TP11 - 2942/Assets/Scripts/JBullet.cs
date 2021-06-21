using UnityEngine;

public class JBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 20;
    private Animator _animator;
    private BoxCollider2D _collider;
    Renderer _renderer;
    Vector3 _direction;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();
        _direction = transform.parent.up;
        gameObject.transform.SetParent(null);
    }

    private void Update()
    {
        Move();
        if (!_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        _rb.MovePosition(new Vector3(_rb.position.x,_rb.position.y,0.0f) + _direction * (_speed * Time.deltaTime));
    }

    public void Damage()
    {
        _animator.SetBool("Death", true);
    }

    public void Death()
    {
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
