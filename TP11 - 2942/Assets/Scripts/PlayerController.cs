using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHittable
{
    public static Action<int> onPlayerDamage;
    public static Action onPlayerDeath;
    public static Action<int> onBombFired;
    int _energy = 3;
    int _bombsLeft = 3;
    bool _alternativeFire;
    [SerializeField]
    float _speed = 15;
    float _xOffset = 0.5f;
    [SerializeField]
    float _fireRate = 0.50f;
    float _fireCooldown;
    float _invulnerabilityTime = 2.0f;
    float _invulnerabilityCooldown = 0.0f;
    Vector3 movement;
    GameObject _bullet;
    GameObject _bomb;
    Renderer _bulletRenderer;
    Renderer _renderer;
    Animator _animator;

    private void OnEnable()
    {
        EnergyUp.energyUp += AddEnergy;
    }

    private void OnDisable()
    {
        EnergyUp.energyUp -= AddEnergy;
    }

    void Start()
    {
        _bullet = Resources.Load<GameObject>("Bullet");
        _bomb = Resources.Load<GameObject>("Bomb");
        _renderer = GetComponent<Renderer>();
        _bulletRenderer = _bullet.GetComponent<Renderer>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * _speed * Time.deltaTime;
        _fireCooldown += Time.deltaTime;
        _invulnerabilityCooldown += Time.deltaTime;
        if (Input.GetKey(KeyCode.L) && _fireCooldown >= _fireRate)
        {
            fireBullet();
        }
        if (Input.GetKeyDown(KeyCode.Space) && _bombsLeft >0)
        {
            fireBomb();
            _bombsLeft--;
            onBombFired?.Invoke(_bombsLeft);
        }
    }
    private void FixedUpdate()
    {
        transform.position += movement;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x,0.04f,0.96f);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void fireBullet()
    {
        if (_alternativeFire)
        {
            GameObject bulletInstance = Instantiate(_bullet,transform.position + new Vector3(-_xOffset, _bulletRenderer.bounds.size.y + _renderer.bounds.extents.y, 0.0f), transform.rotation , transform);
            _alternativeFire = false;
        }
        else
        {
            GameObject bulletInstance = Instantiate(_bullet, transform.position + new Vector3(_xOffset, _bulletRenderer.bounds.size.y+_renderer.bounds.extents.y, 0.0f), transform.rotation,transform);
            _alternativeFire = true;
        }
        _fireCooldown = 0.0f;
    }
    void fireBomb()
    {
        GameObject bombInstance = Instantiate(_bomb, transform.position,Quaternion.identity);
    }
    public void Damage()
    {
        if (_invulnerabilityCooldown >= _invulnerabilityTime)
        {
            Debug.Log("Recibi daño");
            onPlayerDamage?.Invoke(_energy);
            _invulnerabilityCooldown = 0.0f;
        }
        if (_energy <= 0)
        {
            _animator.SetBool("Death", true);
        }
    }
    public void Death()
    {
        Debug.Log("Me mori");
        onPlayerDeath?.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHittable hit = collision.collider.GetComponent<IHittable>();
        if (hit != null)
        {
            hit.Damage();
            Damage();
        }
    }

    void AddEnergy()
    {
        if (_energy < 3)
        {
            _energy++;
        }
    }
}
