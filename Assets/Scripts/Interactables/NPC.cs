using System.Collections;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractible
{
    public PlayerInputControls playerInput;
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;

    public int dialogueIndex = 0;
    private bool isTyping, isDialogueActive;

    public void Interact()
    {
        Debug.Log("interacting with NPC");
       
        if (dialogueData == null)
            return;

        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartDialogue();
        }
    }

    public void OnNotTouchingPlayer()
    {
        //what happens when walks away from npc
        Debug.Log("Player left NPC");
    }

    public void OnTouchingPlayer()
    {
        //what happens when player is near npc
        Debug.Log("Player is near NPC");
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        dialoguePanel.SetActive(true);

        //disable player movement
        if (playerInput != null)
            playerInput.inputs.Disable();

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);

        //enable controls again
        if (playerInput != null)
            playerInput.inputs.Enable();
    }
}

