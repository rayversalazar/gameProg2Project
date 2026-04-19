using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenuAttribute(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public string[] dialogueLines;
    public bool[] autoProgressLines; // If true, the dialogue will automatically progress after a short delay
    public float autoProgressDelay = 2f; // Time to wait before auto-progressing
    public float typingSpeed = 0.1f; // Time between each character appearing
    public AudioClip voiceSound;
    public float voicePitch = 1f;
}
