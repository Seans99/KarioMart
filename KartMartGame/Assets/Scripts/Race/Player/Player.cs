using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _carDrift = 0.95f;
    [SerializeField] private InputAction _playerControls;

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

    public void ReducedSpeed()
    {
        StartCoroutine(ReduceSpeedCourotine());
    }

    IEnumerator ReduceSpeedCourotine()
    {
        _speed /= 2;
        yield return new WaitForSeconds(2);
        _speed *= 2;
    }
}
