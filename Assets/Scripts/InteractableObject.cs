using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public int pickups = 0;

    private GameObject scoreText;
    private GameObject characterText;
    public string text;

    public string[] sentences;

    public enum ObjectType
    {
        Pickup,
        Info,
        Dialogue
    }

    public void Start()
    {
        scoreText = GameObject.Find("Score Text");
        characterText = GameObject.Find("Character Text");
    }

    public ObjectType type;

    public void Activate()
    {
        if (type == ObjectType.Info)
        {
            Info();
        }
        if (type == ObjectType.Pickup)
        {
            Pickup();
        }
        if (type == ObjectType.Dialogue)
        {
            Dialogue();
        }
    }

    private void Info()
    {
        characterText.SetActive(true);
        characterText.GetComponent<TextMeshProUGUI>().text = text;
        StartCoroutine(DeleteText());
    }

    private void Pickup()
    {
        pickups++;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + pickups.ToString();
        //Debug.Log("Picked Up Item!");
        Destroy(gameObject);
    }

    private void Dialogue()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.GameState.Dialogue;
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
    }

    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(2.5f);
        characterText.GetComponent<TextMeshProUGUI>().text = null;
        characterText.SetActive(false);
    }
}
