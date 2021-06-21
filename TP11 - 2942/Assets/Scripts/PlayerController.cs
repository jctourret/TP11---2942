using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool _alternativeFire;
    [SerializeField]
    float _speed = 15;
    float _xOffset = 0.3f;
    [SerializeField]
    float _fireRate = 0.50f;
    float _fireCooldown;
    Vector3 movement;
    GameObject _bullet;
    GameObject _bomb;
    Renderer _bulletRenderer;

    void Start()
    {
        _bullet = Resources.Load<GameObject>("Bullet");
        _bomb = Resources.Load<GameObject>("Bomb");
        _bulletRenderer = _bullet.GetComponent<Renderer>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * _speed * Time.deltaTime;
        _fireCooldown += Time.deltaTime;
        if (Input.GetKey(KeyCode.L) && _fireCooldown >= _fireRate)
        {
            fireBullet();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBomb();
        }
    }

    private void FixedUpdate()
    {
        transform.position += movement;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void fireBullet()
    {
        if (_alternativeFire)
        {
            GameObject bulletInstance = Instantiate(_bullet,transform.position + new Vector3(-_xOffset, _bulletRenderer.bounds.size.y,0.0f),Quaternion.identity,transform);
            _alternativeFire = false;
        }
        else
        {
            GameObject bulletInstance = Instantiate(_bullet, transform.position + new Vector3(_xOffset, _bulletRenderer.bounds.size.y, 0.0f), Quaternion.identity,transform);
            _alternativeFire = true;
        }
        _fireCooldown = 0.0f;
    }

    void fireBomb()
    {
        GameObject bombInstance = Instantiate(_bomb, transform.position,Quaternion.identity);
    }


}
