using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField] private Image DialogueUI;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI DialogueText;

    public bool isDialogueOpen = false;

    private void Awake()
    {
        DialogueUI.gameObject.SetActive(false);
        NameText.gameObject.SetActive(false);
        DialogueText.gameObject.SetActive(false);
    }
    public void StartDialogue()
    {
        DialogueUI.gameObject.SetActive(true);
        NameText.gameObject.SetActive(true);
        DialogueText.gameObject.SetActive(true);
        isDialogueOpen = true;
    }
    public void ShowDialogue(string name, string dialogue)
    {
        NameText.text = name.ToString();
        DialogueText.text = dialogue.ToString();
    }
    public void FinishDialogue()
    {
        DialogueUI.gameObject.SetActive(false);
        NameText.gameObject.SetActive(false);
        DialogueText.gameObject.SetActive(false);
        isDialogueOpen = false;
    }
    public IEnumerator ShowDialogueXseconds(string name, string text, float time)
    {
        StartDialogue();
        NameText.text = name.ToString();
        DialogueText.text = text.ToString();
        yield return new WaitForSeconds(time);
        FinishDialogue();
    }
}
