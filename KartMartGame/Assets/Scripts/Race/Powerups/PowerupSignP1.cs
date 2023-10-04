using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSignP1 : MonoBehaviour
{
    [Header("Powerup emblems")]
    [SerializeField] GameObject _oilPowerupEmblem;
    [SerializeField] GameObject _gunPowerUpEmblem;
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
                    _gunPowerUpEmblem.SetActive(false);
                    break;

                case 2:
                    _speedPowerupEmblem.SetActive(true);
                    _oilPowerupEmblem.SetActive(false);
                    _gunPowerUpEmblem.SetActive(false);
                    break;

                case 3:
                    _gunPowerUpEmblem.SetActive(true);
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
        _oilPowerupEmblem.SetActive(false);
        _player1.GetComponent<Player>().DropOil();
        ResetSO();
    }

    public void SpeedPowerupdUsed()
    {
        _speedPowerupEmblem.SetActive(false);
        _player1.GetComponent<Player>().IncreaseSpeed();
        ResetSO();
    }

    public void GunPowerupUsed()
    {
        _gunPowerUpEmblem.SetActive(false);
        ResetSO();
    }

    void ResetSO()
    {
        _playerCollectedPowerup.P1Powerup = 0;
        _playerCollectedPowerup.P1Collected = false;
    }
}
