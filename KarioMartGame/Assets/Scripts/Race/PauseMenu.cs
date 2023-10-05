using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu buttons")]
    [SerializeField] Button _restartBtn;
    [SerializeField] Button _mainMenuBtn;
    [SerializeField] Button _closeMenuBtn;

    void Start()
    {
        Button restart = _restartBtn.GetComponent<Button>();
        Button titleScreen = _mainMenuBtn.GetComponent<Button>();
        Button close = _closeMenuBtn.GetComponent<Button>();

        restart.onClick.AddListener(Restart);
        titleScreen.onClick.AddListener(MainMenu);
        close.onClick.AddListener(CloseMenu);
    }

    void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2); // Race scene
    }

    void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0); // Main menu
    }

    void CloseMenu()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
