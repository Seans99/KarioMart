using System.Collections;
using UnityEngine;

public class Oil : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (other.CompareTag("Player1"))
        {
            player.ReducedSpeed();
            Destroy(gameObject);
        }
        if (other.CompareTag("Player2"))
        {
            player.ReducedSpeed();
            Destroy(gameObject);
        }
    }
}
