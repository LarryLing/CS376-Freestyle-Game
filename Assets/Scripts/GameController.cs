using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public StartScreen startScreen;

    private int coinsCollected;

    public TMP_Text coinsCollectedTMP;

    public bool isGameRunning;

    private Camera mainCamera;

    void Start()
    {
        startScreen.DisplayStartScreen();

        isGameRunning = false;

        mainCamera = FindObjectOfType<Camera>();

        SetCoinsCollected(0);
    }

    public void StartGame()
    {
        startScreen.HideStartScreen();
        isGameRunning = true;
    }

    public void GameOver()
    {
        isGameRunning = false;
        gameOverScreen.DisplayGameOverScreen(coinsCollected);
    }

    public int GetCoinsCollected()
    {
        return coinsCollected;
    }

    public void SetCoinsCollected(int newCoinsCollected)
    {
        coinsCollected = newCoinsCollected;
        coinsCollectedTMP.text = $"Coins Collected: {coinsCollected}";
    }
}
