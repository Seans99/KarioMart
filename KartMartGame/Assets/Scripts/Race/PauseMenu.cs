using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu buttons")]
    [SerializeField] Button _restartBtn;
    [SerializeField] Button _mainMenuBtn;
    [SerializeField] Button _closeMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button restart = _restartBtn.GetComponent<Button>();
        Button titleScreen = _mainMenuBtn.GetComponent<Button>();
        Button close = _closeMenuBtn.GetComponent<Button>();

        restart.onClick.AddListener(Restart);
        titleScreen.onClick.AddListener(TitleScreen);
        close.onClick.AddListener(CloseMenu);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void TitleScreen()
    {
        SceneManager.LoadScene(0); // Title screen
    }

    void CloseMenu()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
