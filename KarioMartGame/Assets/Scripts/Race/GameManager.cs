using System.Collections;
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
    [SerializeField] GameObject _laps;
    [SerializeField] GameObject _p1PowerupSign;
    [SerializeField] GameObject _p2PowerupSign;

    [Header("Leaderboard")]
    [SerializeField] GameObject _leaderboard;
    [SerializeField] TextMeshProUGUI _firstPlace;
    [SerializeField] TextMeshProUGUI _secondPlace;

    [Header("SO")]
    [SerializeField] GameData _gameData;
    [SerializeField] PlayerCollectedPowerup _playerCollectedPowerup;

    private int _currentLapP1 = 0;
    private int _currentLapP2 = 0;

    void Start()
    {
        // Reset collected powerups SO
        _playerCollectedPowerup.P1Collected = false;
        _playerCollectedPowerup.P1Powerup = 0;
        _playerCollectedPowerup.P2Collected = false;
        _playerCollectedPowerup.P2Powerup = 0;

        SpriteRenderer playerCar1 = _player1.gameObject.GetComponent<SpriteRenderer>();
        playerCar1.sprite = _gameData.Player1;

        SpriteRenderer playerCar2 = _player2.gameObject.GetComponent<SpriteRenderer>();
        playerCar2.sprite = _gameData.Player2;

        GameManagerStatic.gameManager = this;
        Instantiate(_tracks[_gameData.TrackId], transform.position, Quaternion.identity);

        _laps.SetActive(true);
        _p1PowerupSign.gameObject.SetActive(true);
        _p2PowerupSign.gameObject.SetActive(true);

        _player1.gameObject.SetActive(true);
        _player2.gameObject.SetActive(true);
        _player1.GetComponent<Player>().enabled = false; 
        _player2.GetComponent<Player>().enabled = false;

        StartCoroutine(CountDown());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(true);
        }
        
        if (_currentLapP1 > 3 || _currentLapP2 > 3)
        {
            if (_currentLapP1 > 3)
            {
                _firstPlace.text = "1. P1";
                _secondPlace.text = "2. P2";
            }
            else
            {
                _firstPlace.text = "1. P2";
                _secondPlace.text = "2. P1";
            }
            _player1.gameObject.SetActive(false);
            _player2.gameObject.SetActive(false);
            EndRace();
        }
    }

    IEnumerator CountDown() 
    {
        int count = 3;
        _startupText.gameObject.SetActive(true);
        _startupText.text = "Starting in...";
        yield return new WaitForSeconds(1.5f);
        while (count > 0)
        {
            _startupText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        _startupText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        _startupText.gameObject.SetActive(false);
        
        _player1.GetComponent<Player>().enabled = true;
        _player2.GetComponent<Player>().enabled = true;
    }

    void EndRace()
    {
        _player1.gameObject.SetActive(false);
        _player2.gameObject.SetActive(false);
        _laps.gameObject.SetActive(false);
        _leaderboard.gameObject.SetActive(true);
    }

    public void SetLap(string player)
    {
        switch (player)
        {
            case "Player1":
                if (_currentLapP1 <= 3)
                {
                    _currentLapP1++;
                    _p1Laps.text = "P1: " + _currentLapP1 + "/3";
                }
                break;

            case "Player2":
                if (_currentLapP2 <= 3)
                {
                    _currentLapP2++;
                    _p2Laps.text = "P2: " + _currentLapP2 + "/3";
                }
                break;
        }
    }
}
