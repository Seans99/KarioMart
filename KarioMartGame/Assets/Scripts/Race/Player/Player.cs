using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _carDrift = 0.95f;
    [SerializeField] private InputAction _playerControls;

    [Header("Prefabs")]
    [SerializeField] GameObject _oilPrefab;
    [SerializeField] GameObject _bulletsPrefab;

    [Header("Powerup settings")]
    [SerializeField] private float _speedIncrease = 2f;
    [SerializeField] private float _speedReduction = 2.5f;

    private Rigidbody2D rb;

    float rotationAngle = 0;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = _playerControls.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    void Movement()
    {
        rb.AddForce(transform.up * moveDirection.y * _speed);

        Vector2 forward = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 right = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forward + right * _carDrift;
    }

    void Rotation()
    {
        float minSpeedBeforeTurn = (rb.velocity.magnitude / 6);
        minSpeedBeforeTurn = Mathf.Clamp01(minSpeedBeforeTurn);

        rotationAngle -= moveDirection.x * _rotationSpeed * minSpeedBeforeTurn;
        rb.MoveRotation(rotationAngle);
    }

    public void DropOil()
    {
        Instantiate(_oilPrefab, transform.position, Quaternion.identity);
    }

    public void ReducedSpeed()
    {
        rb.velocity /= _speedReduction;
    }

    public void IncreaseSpeed()
    {
        rb.velocity *= _speedIncrease;
    }

    public void Fire()
    {
        Vector3 spawnPosition = transform.position + transform.up * 1.5f;
        Instantiate(_bulletsPrefab, spawnPosition, Quaternion.Euler(0, 0, rb.rotation));
    }

    public void Hit()
    {
        rb.velocity /= _speedReduction;
    }
}
