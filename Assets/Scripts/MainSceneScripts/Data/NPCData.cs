using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCData
{
    public int NPCID {  get; set; }
    public string name {  get; set; }
    public string[] dialogues { get; set; }
    public string sceneName {  get; set; }
}
