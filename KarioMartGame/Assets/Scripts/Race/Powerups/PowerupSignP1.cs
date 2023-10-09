using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSignP1 : MonoBehaviour
{
    [Header("Powerup emblems")]
    [SerializeField] GameObject _oilPowerupEmblem;
    [SerializeField] GameObject _barrelPowerUpEmblem;
    [SerializeField] GameObject _speedPowerupEmblem;

    [Header("SO")]
    [SerializeField] PlayerCollectedPowerup _playerCollectedPowerup;

    [Header("Player1")]
    [SerializeField] GameObject _player1;

    // Update is called once per frame
    void Update()
    {
        if (_playerCollectedPowerup.P1Collected == true)
        {
            switch(_playerCollectedPowerup.P1Powerup)
            {
                case 1:
                    _oilPowerupEmblem.SetActive(true);
                    _speedPowerupEmblem.SetActive(false);
                    _barrelPowerUpEmblem.SetActive(false);
                    break;

                case 2:
                    _speedPowerupEmblem.SetActive(true);
                    _oilPowerupEmblem.SetActive(false);
                    _barrelPowerUpEmblem.SetActive(false);
                    break;

                case 3:
                    _barrelPowerUpEmblem.SetActive(true);
                    _oilPowerupEmblem.SetActive(false);
                    _speedPowerupEmblem.SetActive(false);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_playerCollectedPowerup.P1Collected == true && _playerCollectedPowerup.P1Powerup == 1)
            {
                OilPowerupUsed();
            }
            if (_playerCollectedPowerup.P1Collected == true && _playerCollectedPowerup.P1Powerup == 2)
            {
                SpeedPowerupdUsed();
            }
            if (_playerCollectedPowerup.P1Collected == true && _playerCollectedPowerup.P1Powerup == 3)
            {
                GunPowerupUsed();
            }
        }
    }

    public void OilPowerupUsed()
    {
        if (_oilPowerupEmblem == null)
        {
            Debug.LogError("Oil powerup emblem is NULL");
        }
        if (_player1 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _oilPowerupEmblem.SetActive(false);
        _player1.GetComponent<Player>().DropOil();
        ResetSO();
    }

    public void SpeedPowerupdUsed()
    {
        if (_speedPowerupEmblem == null)
        {
            Debug.LogError("Speed powerup emblem is NULL");
        }
        if (_player1 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _speedPowerupEmblem.SetActive(false);
        _player1.GetComponent<Player>().IncreaseSpeed();
        ResetSO();
    }

    public void GunPowerupUsed()
    {
        if (_barrelPowerUpEmblem == null)
        {
            Debug.LogError("Barrel powerup emblem is NULL");
        }
        if (_player1 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _barrelPowerUpEmblem.SetActive(false);
        StartCoroutine(GunFiring());
        ResetSO();
    }

    IEnumerator GunFiring()
    {
        if (_player1 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _player1.GetComponent<Player>().Fire();
        yield return new WaitForSeconds(0.5f);
    }

    void ResetSO()
    {
        if (_playerCollectedPowerup == null)
        {
            Debug.LogError("_playerCollectedPowerup is NULL");
        }
        _playerCollectedPowerup.P1Powerup = 0;
        _playerCollectedPowerup.P1Collected = false;
    }
}
