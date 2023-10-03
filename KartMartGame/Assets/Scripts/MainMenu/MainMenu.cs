using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu buttons")]
    [SerializeField] Button _playBtn;
    [SerializeField] Button _quitBtn;

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
