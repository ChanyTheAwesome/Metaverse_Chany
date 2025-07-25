using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public int PlayerIndex;
    [SerializeField] private GameObject[] PlayerPrefabs;

    public void CreatePlayer()
    {
        GameObject PlayerWithIndex = PlayerPrefabs[PlayerIndex];
        GameObject Player = Instantiate(PlayerWithIndex, this.transform.position, Quaternion.identity);
        GameManager.Instance.SendPlayerToGM(Player);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        PlayerIndex = GameManager.Instance.CharacterIndex;
        if (PlayerIndex == -1)
        {
            return;
        }
        else
        {
            CreatePlayer();
        }
    }
}