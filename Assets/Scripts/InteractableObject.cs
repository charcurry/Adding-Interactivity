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

    public enum ObjectType
    {
        Pickup,
        Info
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

    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(5);
        characterText.GetComponent<TextMeshProUGUI>().text = null;
        characterText.SetActive(false);
    }
}
