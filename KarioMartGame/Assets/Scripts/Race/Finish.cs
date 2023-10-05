using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            GameManagerStatic.gameManager.SetLap(other.tag);
        }
        if (other.CompareTag("Player2"))
        {
            GameManagerStatic.gameManager.SetLap(other.tag);
        }
    }
}
