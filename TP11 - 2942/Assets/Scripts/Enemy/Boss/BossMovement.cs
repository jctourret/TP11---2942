using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]private float _speed;
    private Rigidbody2D _rb;
    [SerializeField] private float _limitY;
    private Camera _camera;
    private float _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = 1;
    }
    
    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        if (_rb.position.y >= _limitY)
            _rb.MovePosition(_rb.position + (Vector2)gameObject.transform.up*(_speed * Time.fixedDeltaTime));

        else
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (Mathf.Clamp01(pos.x) >= 0.89f)
                _direction = 1;
            else if (Mathf.Clamp01(pos.x) <= 0.090f)
                _direction = -1;
            _rb.MovePosition(_rb.position + (Vector2) gameObject.transform.right * (_direction * (_speed * Time.fixedDeltaTime)));
        }

    }
    
   
}
