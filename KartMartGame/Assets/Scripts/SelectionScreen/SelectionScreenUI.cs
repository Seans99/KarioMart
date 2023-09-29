using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionScreenUI : MonoBehaviour
{
    [Header("Selection screen buttons")]
    [SerializeField] private Button _startRaceBtn;
    [SerializeField] private Button _titleScreenBtn;

    void Start()
    {
        Button start = _startRaceBtn.GetComponent<Button>();
        Button title = _titleScreenBtn.GetComponent<Button>();
        start.onClick.AddListener(StartRace);
        title.onClick.AddListener(ReturnToTitleScreen);
    }

    void StartRace()
    {
        SceneManager.LoadScene(2); // Race scene
    }

    void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0); // Main menu
    }
}
