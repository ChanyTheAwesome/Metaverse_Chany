using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private string NPCpath;
    private static ResourceManager instance;
    public static ResourceManager Instance {  get { return instance; } }

    public Dictionary<int, NPCData> NPCDict = new Dictionary<int, NPCData>();
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NPCpath = Path.Combine(Application.dataPath + "/JsonData/", "NPCData.json");
        LoadNPC();
    }

    private void LoadNPC()
    {
        if (!File.Exists(NPCpath))
        {
            return;
        }
        else
        {
            List<NPCData> npcdatas = LoadJsonData<NPCData>(NPCpath);
            foreach (NPCData data in npcdatas)
            {
                NPCDict.Add(data.NPCID, data);
            }
        }
    }
    public List<T> LoadJsonData<T>(string jsonPath)
    {
        string json = File.ReadAllText(jsonPath);
        return JsonConvert.DeserializeObject<List<T>>(json);
    }
}
