using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;
using System;
using NUnit.Framework;

public class FlavorTextHandler : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI textComponent;
    public string text;
    public float textSpeed;
    public float textStartDelay;

    public bool isActive = false; // whether the flavor text is running
    public bool isComplete = false; // whether the flavor text is completed
    public bool isTouching = false; // whether the player is touching an interactable object

    void Start()
    {
        text = textComponent.text;
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) // prevent spamming E
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isTouching)
                {
                    isActive = true;
                }

                if (isComplete)
                {
                    StopAllCoroutines();
                    textComponent.text = "";
                    dialogueBox.SetActive(false);
                    isComplete = false;
                    isActive = false;
                }
                else if (text != "" && text != null)
                {
                    dialogueBox.SetActive(true);
                    StartCoroutine(TypeLine());
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        yield return new WaitForSeconds(textStartDelay);
        foreach (char c in text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isActive = false;
        isComplete = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flavor Text"))
        {
            isTouching = true;
            FlavorText ft = collision.gameObject.GetComponent<FlavorText>();
            text = ft.text;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flavor Text"))
        {
            isTouching = false;
            text = "";
        }
    }
}
