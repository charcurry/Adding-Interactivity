using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        SuspendPlayerControl();

        foreach (string sentence in sentences) 
        {
            dialogue.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string currentLine = dialogue.Dequeue();

        dialogueText.text = currentLine;
    }

    void SuspendPlayerControl()
    {
        player.GetComponent<CharacterController2D>().enabled = false;
        player.GetComponent<Interaction>().enabled = false;
        //Cursor.visible = true;
        animator.enabled = false;
        //animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void ResumePlayerControl()
    {
        player.GetComponent<CharacterController2D>().enabled = true;
        player.GetComponent<Interaction>().enabled = true;
        //Cursor.visible = false;
        animator.enabled = true;
        //animator.SetFloat("Speed", 1);
    }

    public void EndDialogue()
    {
        ResumePlayerControl();
        dialogueUI.SetActive(false);
        FindObjectOfType<GameManager>().gameState = GameManager.GameState.Gameplay;
    }
}
