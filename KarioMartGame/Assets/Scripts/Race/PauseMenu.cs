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
        Button mainMenu = _mainMenuBtn.GetComponent<Button>();
        Button close = _closeMenuBtn.GetComponent<Button>();

        if (restart == null)
        {
            Debug.LogError("Restart button is NULL");
        }
        if (mainMenu == null)
        {
            Debug.LogError("Main menu button is NULL");
        }
        if (close == null)
        {
            Debug.LogError("Close button is NULL");
        }

        restart.onClick.AddListener(Restart);
        mainMenu.onClick.AddListener(MainMenu);
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
