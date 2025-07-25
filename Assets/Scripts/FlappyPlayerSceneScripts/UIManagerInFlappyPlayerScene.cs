using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerInFlappyPlayerScene : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public Button restartButton;
    public Button backToMainSceneButton;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI localBestScoreText;
    public TextMeshProUGUI localBestScore;
    public Image tutorial;
    public Button tutorialButton;
    public static bool isFirstPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        if(restartText == null)
        {
            Debug.LogError("No restart text");
        }
        if (scoreText == null)
        {
            Debug.LogError("No score text");
        }
        restartText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        backToMainSceneButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(OnClickRestartButton);
        backToMainSceneButton.onClick.AddListener(OnClickBackToMainSceneMutton);
        tutorial.gameObject.SetActive(false);
        tutorialButton.onClick.AddListener(StartGame);
        bestScoreText.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(false);
        localBestScoreText.gameObject.SetActive(false);
        localBestScore.gameObject.SetActive(false);
    }
    public void SetGameOver(int bestScoreInt, int localBestScoreInt)
    {
        restartText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        backToMainSceneButton.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        bestScore.gameObject.SetActive(true);
        localBestScoreText.gameObject.SetActive(true);
        localBestScore.gameObject.SetActive(true);
        SetBestScoreText(bestScoreInt);
        SetLocalBestScoreText(localBestScoreInt);
    }
    private void SetBestScoreText(int bestScoreInt)
    {
        bestScore.text = bestScoreInt.ToString();
    }
    private void SetLocalBestScoreText(int localbestScoreInt)
    {
        localBestScore.text = localbestScoreInt.ToString();
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void ShowTutorial()
    {
        tutorial.gameObject.SetActive(true);
        isFirstPlay = false;
    }
    public void StartGame()
    {
        tutorial.gameObject.SetActive(false);
        GameManagerInFlappyPlayerScene.Instance.GameStart();
    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("FlappyPlayerScene");
    }
    public void OnClickBackToMainSceneMutton()
    {
        SceneManager.LoadScene("MainScene");
    }
}