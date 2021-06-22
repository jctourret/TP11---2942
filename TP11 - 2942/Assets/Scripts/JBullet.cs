using UnityEngine;

public class JBullet : MonoBehaviour, IHittable
{
    public static float scaleMultiplier = 1.0f;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 20;
    private Animator _animator;
    private BoxCollider2D _collider;
    Renderer _renderer;
    Vector3 _direction;

    private void OnEnable()
    {
        BulletScaleUp.bulletScaleUp += scaleUp;
    }

    private void OnDisable()
    {
        BulletScaleUp.bulletScaleUp -= scaleUp;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();
        _direction = transform.parent.up;
        gameObject.transform.SetParent(null);
        transform.localScale = transform.localScale * scaleMultiplier;
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
        _rb.MovePosition(_rb.position + (Vector2)_direction * (_speed * Time.deltaTime));
    }

    public void Damage()
    {
        _animator.SetBool("Death", true);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void scaleUp(float buff)
    {
        scaleMultiplier += buff;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHittable hit = collision.transform.GetComponent<IHittable>();
        if (hit != null )
        {
            hit.Damage();
        }
    }
}
