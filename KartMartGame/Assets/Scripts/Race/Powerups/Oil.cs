using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (other.CompareTag("Player1"))
        {
            player.ReducedSpeed();
        }
        if (other.CompareTag("Player2"))
        {
            player.ReducedSpeed();
        }
    }
}
