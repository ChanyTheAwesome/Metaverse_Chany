using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    [SerializeField] private ManagerNPCController ManagerNPCController;
    private int characterIndex = -1;
    public int CharacterIndex { get { return characterIndex; } }
    public int bestScore;
    GameObject player;
    public int playerDirection;
    public int NPCHit;
    public bool enableAttack;
    public bool isPlayerGotRide;
    public bool isPlayerOnRide;
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
        isPlayerGotRide = false;
        isPlayerOnRide = false;
        enableAttack = false;
        NPCHit = 0;
        bestScore = 0;
        characterIndex = CharacterDataHolder.SendCharacterIndex();
        CharacterDataHolder.destroythis = true;
    }
    public void CallChangeNPC(int index)
    {
        ManagerNPCController.NPCIndex = index;
        ManagerNPCController.ChangeNPCWithIndex();
    }
    public void SendNPCManagerToGM(ManagerNPCController Manager)
    {
        ManagerNPCController = Manager;
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