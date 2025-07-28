using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataHolder : MonoBehaviour
{
    public static int CharacterIndex = 0;
    public static bool destroythis = false;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static int SendCharacterIndex()
    {
        return CharacterIndex;
    }

    private void Update()
    {
        if(destroythis == true)
        {
            Destroy(gameObject);
        }
    }
}
