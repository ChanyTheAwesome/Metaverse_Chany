using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private int characterIndex = -1;
    public int CharacterIndex { get { return characterIndex; } }
    public int bestScore;
    GameObject player;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Init()
    {
        bestScore = 0;
        characterIndex = CharacterDataHolder.SendCharacterIndex();
        CharacterDataHolder.destroythis = true;
    }
    private void Start()
    {
        Init();
    }

    public void SendPlayerToGM(GameObject go)
    {
        player = go;
    }
    public GameObject SendPlayer()
    {
        return player;
    }
}