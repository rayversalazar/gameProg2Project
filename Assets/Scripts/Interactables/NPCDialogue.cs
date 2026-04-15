using UnityEngine;
using System.Collections.Generic;
using System.Collections;

    [CreateAssetMenuAttribute(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f; // Time between each character appearing
    public AudioClip voiceSound;
}
