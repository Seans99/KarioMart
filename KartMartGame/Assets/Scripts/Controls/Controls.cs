using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button _backButton;
    
    void Start()
    {
        Button back = _backButton.GetComponent<Button>();
        back.onClick.AddListener(BackToMainMenu);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // Main menu
    }

}
