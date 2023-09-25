using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player prefabs")]
    [SerializeField] GameObject player1Prefab;
    [SerializeField] GameObject player2Prefab;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI startupText;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject[] tracks;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }

    IEnumerator CountDown() 
    {
        startupText.gameObject.SetActive(true);
        startupText.text = "Starting in...";
        yield return new WaitForSeconds(1);
        startupText.text = "3";
        yield return new WaitForSeconds(1);
        startupText.text = "2";
        yield return new WaitForSeconds(1);
        startupText.text = "1";
        yield return new WaitForSeconds(1);
        startupText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        startupText.gameObject.SetActive(false);
    }
}
