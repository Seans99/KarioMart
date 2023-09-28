using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player prefabs")]
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [Header("Tracks")]
    [SerializeField] Grid[] tracks;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI startupText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TextMeshProUGUI p1Laps;
    [SerializeField] TextMeshProUGUI p2Laps;

    [Header("Leaderboard")]
    [SerializeField] GameObject leaderboard;
    private List<GameObject> leaderboardList;

    private int currentLapP1 = 0;
    private int currentLapP2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerStatic.gameManager = this;
        Instantiate(tracks[1], transform.position, Quaternion.identity);

        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
        if (currentLapP1 > 3 || currentLapP2 > 3)
        {
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
            EndRace();
        }
    }

    IEnumerator CountDown() 
    {
        startupText.gameObject.SetActive(true);
        startupText.text = "Starting in...";
        yield return new WaitForSeconds(1);
        startupText.text = "3";
        yield return new WaitForSeconds(1);
        startupText.text = "2";
        yield return new WaitForSeconds(1);
        startupText.text = "1";
        yield return new WaitForSeconds(1);
        startupText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        startupText.gameObject.SetActive(false);
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
    }

    public void EndRace()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        leaderboard.gameObject.SetActive(true);
    }

    public void SetLap(string player)
    {
        switch (player)
        {
            case "Player1":
                if (currentLapP1 < 3)
                {
                    currentLapP1++;
                    p1Laps.text = "P1: " + currentLapP1 + "/3";
                }
                break;

            case "Player2":
                if (currentLapP2 < 3)
                {
                    currentLapP2++;
                    p2Laps.text = "P2: " + currentLapP2 + "/3";
                }
                break;
        }
    }
}
