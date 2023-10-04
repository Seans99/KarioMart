using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu buttons")]
    [SerializeField] Button _playBtn;
    [SerializeField] Button _quitBtn;
    [SerializeField] Button _controlsBtn;

    void Start()
    {
        Button play = _playBtn.GetComponent<Button>();
        Button controls = _controlsBtn.GetComponent<Button>();
        Button quit = _quitBtn.GetComponent<Button>();
        play.onClick.AddListener(PlayGame);
        controls.onClick.AddListener(Controls);
        quit.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(1); // Selection screen
    }

    void Controls()
    {
        SceneManager.LoadScene(3); // Controls scene
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
