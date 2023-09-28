using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] GameObject _player1;
    [SerializeField] GameObject _player2;

    [Header("Tracks")]
    [SerializeField] Grid[] _tracks;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI _startupText;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] TextMeshProUGUI _p1Laps;
    [SerializeField] TextMeshProUGUI _p2Laps;

    [Header("Leaderboard")]
    [SerializeField] GameObject _leaderboard;
    private List<GameObject> _leaderboardList;

    [Header("SO")]
    [SerializeField] GameData _gameData;

    private int _currentLapP1 = 0;
    private int _currentLapP2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer playerCar1 = _player1.gameObject.GetComponent<SpriteRenderer>();
        playerCar1.sprite = _gameData.Player1;

        SpriteRenderer playerCar2 = _player1.gameObject.GetComponent<SpriteRenderer>();
        playerCar2.sprite = _gameData.Player2;

        GameManagerStatic.gameManager = this;
        Instantiate(_tracks[1], transform.position, Quaternion.identity);

        _player1.gameObject.SetActive(false);
        _player2.gameObject.SetActive(false);
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
        }
        if (_currentLapP1 > 3 || _currentLapP2 > 3)
        {
            _player1.gameObject.SetActive(false);
            _player2.gameObject.SetActive(false);
            EndRace();
        }
    }

    IEnumerator CountDown() 
    {
        _startupText.gameObject.SetActive(true);
        _startupText.text = "Starting in...";
        yield return new WaitForSeconds(1);
        _startupText.text = "3";
        yield return new WaitForSeconds(1);
        _startupText.text = "2";
        yield return new WaitForSeconds(1);
        _startupText.text = "1";
        yield return new WaitForSeconds(1);
        _startupText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        _startupText.gameObject.SetActive(false);
        _player1.gameObject.SetActive(true);
        _player2.gameObject.SetActive(true);
    }

    public void EndRace()
    {
        _player1.gameObject.SetActive(false);
        _player2.gameObject.SetActive(false);
        _leaderboard.gameObject.SetActive(true);
    }

    public void SetLap(string player)
    {
        switch (player)
        {
            case "Player1":
                if (_currentLapP1 < 3)
                {
                    _currentLapP1++;
                    _p1Laps.text = "P1: " + _currentLapP1 + "/3";
                }
                break;

            case "Player2":
                if (_currentLapP2 < 3)
                {
                    _currentLapP2++;
                    _p2Laps.text = "P2: " + _currentLapP2 + "/3";
                }
                break;
        }
    }
}
