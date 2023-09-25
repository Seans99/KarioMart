using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1lapsText;
    [SerializeField] TextMeshProUGUI p2lapsText;

    private GameManager gameManager;

    private float p1CurrentLap = 0;
    private float p2CurrentLap = 0;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (p1CurrentLap > 3 &&  p2CurrentLap > 3 )
        {
            gameManager.EndRace();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            p1CurrentLap++;
            p1lapsText.text = "P1: " + p1CurrentLap + "/3";

            if (p1CurrentLap > 3)
            {
                gameManager.AddToLeaderboard(other.gameObject);
            }
        }
        if (other.CompareTag("Player2"))
        {
            p2CurrentLap++;
            p2lapsText.text = "P2: " + p2CurrentLap + "/3";

            if (p2CurrentLap > 3)
            {
                gameManager.AddToLeaderboard(other.gameObject);
            }
        }
    }
}
