using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    [Header("Powerup ID")]
    [SerializeField] int _powerupId;

    [Header("SO")]
    [SerializeField] PlayerCollectedPowerup _playerCollectedPowerup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            _playerCollectedPowerup.P1Powerup = _powerupId;
            _playerCollectedPowerup.P1Collected = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player2"))
        {
            _playerCollectedPowerup.P2Powerup = _powerupId;
            _playerCollectedPowerup.P2Collected = true;
            Destroy(gameObject);
        }
    }
}
