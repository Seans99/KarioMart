using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _bulletsSpeed = 8f;

    void Update()
    {
        transform.Translate(Vector3.up * _bulletsSpeed * Time.deltaTime);
    }
}
