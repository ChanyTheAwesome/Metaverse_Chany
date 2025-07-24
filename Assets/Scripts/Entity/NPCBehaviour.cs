using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour, IInteractable
{
    private Image textImage;
    [SerializeField] private Transform player;

    bool isPlayerInRange = false;
    public void Interact()
    {
        Debug.Log("Test2");
        textImage.gameObject.SetActive(false);
    }
    void Start()
    {
        textImage = GetComponentInChildren<Image>();
        textImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if(textImage != null)
            {
                textImage.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (textImage != null)
            {
                textImage.gameObject.SetActive(false);
            }
        }
    }
}
