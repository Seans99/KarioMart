using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button titleScreenBtn;
    [SerializeField] Button closeMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button restart = restartBtn.GetComponent<Button>();
        Button titleScreen = titleScreenBtn.GetComponent<Button>();
        Button close = closeMenuBtn.GetComponent<Button>();

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
        gameObject.SetActive(false);
    }
}
