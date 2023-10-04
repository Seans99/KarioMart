using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSignP2 : MonoBehaviour
{
    [Header("Powerup emblems")]
    [SerializeField] GameObject _oilPowerupEmblem;
    [SerializeField] GameObject _gunPowerUpEmblem;
    [SerializeField] GameObject _speedPowerupEmblem;

    [Header("SO")]
    [SerializeField] PlayerCollectedPowerup _playerCollectedPowerup;

    [Header("Player2")]
    [SerializeField] GameObject _player2;

    // Update is called once per frame
    void Update()
    {
        if (_playerCollectedPowerup.P2Collected == true && _oilPowerupEmblem.activeSelf == false || _gunPowerUpEmblem.activeSelf == false)
        {
            switch (_playerCollectedPowerup.P2Powerup)
            {
                case 1:
                    _oilPowerupEmblem.SetActive(true);
                    break;

                case 2:
                    _speedPowerupEmblem.SetActive(true);
                    break;

                case 3:
                    _gunPowerUpEmblem.SetActive(true);
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
        _oilPowerupEmblem.SetActive(false);
        _player2.GetComponent<Player>().DropOil();
        ResetSO();
    }

    public void SpeedPowerupdUsed()
    {
        _speedPowerupEmblem.SetActive(false);
        _player2.GetComponent<Player>().IncreaseSpeed();
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
