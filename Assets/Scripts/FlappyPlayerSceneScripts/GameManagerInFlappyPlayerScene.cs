using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerInFlappyPlayerScene : MonoBehaviour
{
    string LocalBestScoreKey = "LocalBestScore";
    static GameManagerInFlappyPlayerScene gameManager;
    public static GameManagerInFlappyPlayerScene Instance { get { return gameManager; } }

    private int currentScore = 0;


    UIManagerInFlappyPlayerScene uiManager;
    public UIManagerInFlappyPlayerScene UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManagerInFlappyPlayerScene>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        if (UIManagerInFlappyPlayerScene.isFirstPlay)
        {
            Time.timeScale = 0.0f;
            uiManager.ShowTutorial();
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        int localBestScore;
        int bestScore = GameManager.Instance.bestScore;
        SetScore(ref bestScore, out localBestScore);
        uiManager.SetGameOver(bestScore, localBestScore);
    }
    private void SetScore(ref int bestScore, out int localBestScore)
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            GameManager.Instance.bestScore = currentScore;
        }
        if (PlayerPrefs.HasKey(LocalBestScoreKey))
        {
            localBestScore = PlayerPrefs.GetInt(LocalBestScoreKey);
            if (currentScore > localBestScore)
            {
                localBestScore = currentScore;
                PlayerPrefs.SetInt(LocalBestScoreKey, localBestScore);
            }
        }
        else
        {
            localBestScore = currentScore;
            PlayerPrefs.SetInt(LocalBestScoreKey, currentScore);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
