using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button quitBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button play = playBtn.GetComponent<Button>();
        Button quit = quitBtn.GetComponent<Button>();
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
