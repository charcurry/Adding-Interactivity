using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject currentInteractable;
    public string objectTag = "Interactable";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Near Object");
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.CompareTag(objectTag) == true)
        {
            currentInteractable = collision.gameObject;
        }     
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        currentInteractable = null;
    }
}
