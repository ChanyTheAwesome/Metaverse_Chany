using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerNPCController : MonoBehaviour
{
    public int NPCIndex;
    [SerializeField] private GameObject[] NPCPrefabs;
    private void Start()
    {
        SetIndex();
        CreateNPCWithIndex();
    }
    private void SetIndex()
    {
        if(GameManager.Instance.bestScore >= 20)
        {
            NPCIndex = 1;
        }
        else
        {
            NPCIndex = 0;
        }
    }
    public void CreateNPCWithIndex()
    {
        GameObject NPCwithindex = NPCPrefabs[NPCIndex];
        GameObject NPC_Manager = Instantiate(NPCwithindex, this.transform.position, Quaternion.identity, this.transform);
    }

    public void ChangeNPCWithIndex()
    {
        GameObject NPC = transform.GetChild(0).gameObject;
        Destroy(NPC);
        CreateNPCWithIndex();
    }
}