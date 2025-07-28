using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [SerializeField] private Image whiteFade;

    public DialogueHandler DialogueHandler;

    private void Awake()
    {
        instance = this;
    }

    public void FadeToWhite()
    {
        StartCoroutine(FadeToWhiteCoroutine());
    }
    private IEnumerator FadeToWhiteCoroutine()
    {
        float durationTime = 10.0f;
        float time = 0.0f;
        Color currentColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Color FadeToWhiteColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        while (time < durationTime)
        {
            time += Time.deltaTime;
            whiteFade.color = Color.Lerp(currentColor, FadeToWhiteColor, time / durationTime);

            yield return null;
        }
    }
}