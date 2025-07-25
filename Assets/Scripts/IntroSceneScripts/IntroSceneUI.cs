using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI CharacterSelectText;
    [SerializeField] private TextMeshProUGUI HereWeGoText;
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button AdamButton;
    [SerializeField] private Button AmeliaButton;
    [SerializeField] private CharacterDataHolder CharacterDataHolder;

    Animator animator;
    
    private void Start()
    {
        StartButton.onClick.AddListener(OnClickStartButton);
        ExitButton.onClick.AddListener(OnClickExitButton);
        AdamButton.onClick.AddListener(OnClickAdamButton);
        AmeliaButton.onClick.AddListener(OnClickAmeliaButton);
        animator = ExitButton.GetComponent<Animator>();
        AdamButton.gameObject.SetActive(false);
        AmeliaButton.gameObject.SetActive(false);
        CharacterSelectText.gameObject.SetActive(false);
        HereWeGoText.gameObject.SetActive(false);
    }

    private void OnClickStartButton()
    {
        Destroy(Title.gameObject);
        Destroy(StartButton.gameObject);
        if(ExitButton != null)
        {
            Destroy(ExitButton.gameObject);
        }
        AdamButton.gameObject.SetActive(true);
        AmeliaButton.gameObject.SetActive(true);
        CharacterSelectText.gameObject.SetActive(true);
        HereWeGoText.gameObject.SetActive(true);
    }
    private void OnClickExitButton()
    {
        StartCoroutine(StartAnimation());
    }
    private void OnClickAdamButton()
    {
        CharacterDataHolder.CharacterIndex = 0;
        SceneManager.LoadScene("MainScene");
    }
    private void OnClickAmeliaButton()
    {
        CharacterDataHolder.CharacterIndex = 1;
        SceneManager.LoadScene("MainScene");
    }
    private IEnumerator StartAnimation()
    {
        animator.SetBool("IsPressed", true);
        yield return new WaitForSeconds(1.0f);
        if (ExitButton != null)
        {
            Destroy(ExitButton.gameObject);
        }
    }
    private void Update()
    {
    }
}