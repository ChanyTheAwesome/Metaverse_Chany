using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum NPCType
{
    Dialogue,
    SceneChange,
    Puzzle
}
public class NPCBehaviour : MonoBehaviour, IInteractable
{
    private Image textImage;
    private int currentDialogueIndex = 0;
    [SerializeField] protected int NPCID;
    [SerializeField] private NPCType type;

    bool isPlayerInRange = false;
    public void Interact()
    {
        switch (type)
        {
            case NPCType.Dialogue:
                textImage.gameObject.SetActive(false);
                StartDialogue();
                break;
            case NPCType.SceneChange:
                textImage.gameObject.SetActive(false);
                SceneChange();
                break;
            case NPCType.Puzzle:
                textImage.gameObject.SetActive(false);
                this.gameObject.GetComponent<PuzzleNPCBehaviour>().PuzzleInteract();
                break;
        }
    }
    private void SceneChange()
    {
        SceneManager.LoadScene(ResourceManager.Instance.NPCDict[NPCID].sceneName);
    }
    private void StartDialogue()
    {
        Dialogue(currentDialogueIndex);
    }
    private void Dialogue(int index)
    {
        string NPCName = ResourceManager.Instance.NPCDict[NPCID].name;
        string[] dialogues = ResourceManager.Instance.NPCDict[NPCID].dialogues;

        UIManager.Instance.DialogueHandler.StartDialogue();
        if (currentDialogueIndex <= dialogues.Length)
        {
            if (currentDialogueIndex < dialogues.Length)
            {
                int best_score = PlayerPrefs.GetInt("LocalBestScore");
                string parsedDialogue = dialogues[currentDialogueIndex];
                UIManager.Instance.DialogueHandler.ShowDialogue(NPCName, parsedDialogue);
            }
            currentDialogueIndex++;
        }
        if (currentDialogueIndex > dialogues.Length)
        {
            ExceptionCheck();
            DisableDialogueInterface();
            textImage.gameObject.SetActive(true);
        }
    }
    void DisableDialogueInterface()
    {
        UIManager.Instance.DialogueHandler.FinishDialogue();
        currentDialogueIndex = 0;
    }
    private void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        textImage = GetComponentInChildren<Image>();
        textImage.gameObject.SetActive(false);
    }
    private void ExceptionCheck()
    {
        if (NPCID == 102)
        {
            GameManager.Instance.enableAttack = true;
            GameManager.Instance.CallChangeNPC(2);
        }
    }
    public virtual void Update()
    {   
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (textImage != null)
            {
                textImage.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (UIManager.Instance.DialogueHandler.isDialogueOpen)
            {
                DisableDialogueInterface();
            }
            isPlayerInRange = false;
            if (textImage != null)
            {
                textImage.gameObject.SetActive(false);
            }
        }
    }
}
