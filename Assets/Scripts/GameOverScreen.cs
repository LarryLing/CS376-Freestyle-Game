using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text coinsCollected;

    public void DisplayGameOverScreen(int finalScore)
    {
        gameObject.SetActive(true);

        coinsCollected.text = $"Coins Collected: {finalScore}";
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
