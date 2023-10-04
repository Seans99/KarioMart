using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRandomizer : MonoBehaviour
{
    [Header("Powerups array")]
    [SerializeField] GameObject[] _powerups;

    void Start()
    {
        int randomPowerup = Random.Range(0, _powerups.Length);
        Instantiate(_powerups[randomPowerup], transform.position, Quaternion.identity);
    }
}
