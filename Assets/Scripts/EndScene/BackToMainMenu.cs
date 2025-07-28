using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] Button MainMenuButton;
    void Start()
    {
        MainMenuButton.onClick.AddListener(OnClickMainMenuButton);
    }

    void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
