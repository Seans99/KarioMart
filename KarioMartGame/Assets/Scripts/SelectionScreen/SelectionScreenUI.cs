using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionScreenUI : MonoBehaviour
{
    [Header("Selection screen buttons")]
    [SerializeField] private Button _startRaceBtn;
    [SerializeField] private Button _mainMenuBtn;

    void Start()
    {
        Button start = _startRaceBtn.GetComponent<Button>();
        Button mainMenu = _mainMenuBtn.GetComponent<Button>();
        start.onClick.AddListener(StartRace);
        mainMenu.onClick.AddListener(ReturnToTitleScreen);

        if (start == null)
        {
            Debug.LogError("Start button is NULL");
        }
        if (mainMenu == null)
        {
            Debug.LogError("Main menu button is NULL");
        }
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
