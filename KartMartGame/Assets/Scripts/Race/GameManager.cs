using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player prefabs")]
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI startupText;
    [SerializeField] GameObject pauseMenu;

    [Header("Leaderboard")]
    [SerializeField] GameObject leaderboard;
    private List<GameObject> leaderboardList;

    [SerializeField] GameObject[] tracks;

    // Start is called before the first frame update
    void Start()
    {
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

    public void AddToLeaderboard(GameObject player)
    {
        leaderboardList.Add(player);
    }

    public void EndRace()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        leaderboard.gameObject.SetActive(true);
    }
}
