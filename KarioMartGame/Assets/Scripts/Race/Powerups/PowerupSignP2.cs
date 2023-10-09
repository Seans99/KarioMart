using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSignP2 : MonoBehaviour
{
    [Header("Powerup emblems")]
    [SerializeField] GameObject _oilPowerupEmblem;
    [SerializeField] GameObject _barrelPowerUpEmblem;
    [SerializeField] GameObject _speedPowerupEmblem;

    [Header("SO")]
    [SerializeField] PlayerCollectedPowerup _playerCollectedPowerup;

    [Header("Player2")]
    [SerializeField] GameObject _player2;

    // Update is called once per frame
    void Update()
    {
        if (_playerCollectedPowerup.P2Collected == true)
        {
            switch (_playerCollectedPowerup.P2Powerup)
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

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (_playerCollectedPowerup.P2Collected == true && _playerCollectedPowerup.P2Powerup == 1)
            {
                OilPowerupUsed();
            }
            if (_playerCollectedPowerup.P2Collected == true && _playerCollectedPowerup.P2Powerup == 2)
            {
                SpeedPowerupdUsed();
            }
            if (_playerCollectedPowerup.P2Collected == true && _playerCollectedPowerup.P2Powerup == 3)
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
        if (_player2 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _oilPowerupEmblem.SetActive(false);
        _player2.GetComponent<Player>().DropOil();
        ResetSO();
    }

    public void SpeedPowerupdUsed()
    {
        if (_speedPowerupEmblem == null)
        {
            Debug.LogError("Speed powerup emblem is NULL");
        }
        if (_player2 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _speedPowerupEmblem.SetActive(false);
        _player2.GetComponent<Player>().IncreaseSpeed();
        ResetSO();
    }

    public void GunPowerupUsed()
    {
        if (_barrelPowerUpEmblem == null)
        {
            Debug.LogError("Barrel powerup emblem is NULL");
        }
        if (_player2 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _barrelPowerUpEmblem.SetActive(false);
        StartCoroutine(GunFiring());
        ResetSO();
    }

    IEnumerator GunFiring()
    {
        if (_player2 == null)
        {
            Debug.LogError("Player 1 is NULL");
        }
        _player2.GetComponent<Player>().Fire();
        yield return new WaitForSeconds(0.5f);
    }

    void ResetSO()
    {
        if (_playerCollectedPowerup == null)
        {
            Debug.LogError("_playerCollectedPowerup is NULL");
        }
        _playerCollectedPowerup.P2Powerup = 0;
        _playerCollectedPowerup.P2Collected = false;
    }
}
