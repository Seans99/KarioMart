using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _playBtn;
    [SerializeField] Button _quitBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button play = _playBtn.GetComponent<Button>();
        Button quit = _quitBtn.GetComponent<Button>();
        play.onClick.AddListener(PlayGame);
        quit.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1); // Selection screen
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
