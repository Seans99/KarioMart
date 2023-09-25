using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionScreenUI : MonoBehaviour
{
    [SerializeField] private Button startRaceBtn;
    [SerializeField] private Button titleScreenBtn;

    void Start()
    {
        Button start = startRaceBtn.GetComponent<Button>();
        Button title = titleScreenBtn.GetComponent<Button>();
        start.onClick.AddListener(StartRace);
        title.onClick.AddListener(ReturnToTitleScreen);
    }

    void StartRace()
    {
        SceneManager.LoadScene(2); // Race scene
    }

    void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0); // Title screen
    }
}
