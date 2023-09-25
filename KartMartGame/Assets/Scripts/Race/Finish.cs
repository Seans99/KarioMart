using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lapsText;
    [SerializeField] GameObject leaderboard;

    private float currentLap = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;
            lapsText.text = "Laps: " + currentLap + "/3";

            if (currentLap > 3)
            {
                leaderboard.SetActive(true);
            }
        }
    }
}
