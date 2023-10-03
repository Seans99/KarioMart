using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _returningCounter;

    [SerializeField] private int _returnCounter = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf == true)
        {
            StartCoroutine(ReturningCounterCourotine());
        }
    }

    IEnumerator ReturningCounterCourotine()
    {
        while(_returnCounter >= 0)
        {
            _returningCounter.text = _returnCounter.ToString();
            yield return new WaitForSeconds(1);
            _returnCounter--;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1); // Selection screen
    }
}
