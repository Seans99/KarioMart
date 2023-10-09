using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _bulletsSpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * _bulletsSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Destroy(gameObject);
            other.GetComponent<Player>().Hit();
        }
        if (other.CompareTag("Player2"))
        {
            Destroy(gameObject);
            other.GetComponent<Player>().Hit();
        }
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
