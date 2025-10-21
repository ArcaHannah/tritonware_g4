using UnityEngine;
using System.Collections;

public class FlavorTextHandler : MonoBehaviour
{
    
    public GameObject dialogueBox;
    public TMPro.TextMeshProUGUI textComponent;
    public string[] text;
    public float textSpeed;
    public PlayerMovement playerMovementScript;

    private int index;
    private bool isTouching = false; // whether the player is touching an interactable object
    public bool isActive = false; // whether the flavor text is running
    private bool isTyping = false; // whether the text is being typed

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>(); ;
        textComponent.text = string.Empty;
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (isTouching && Input.GetKeyDown(KeyCode.E))
        {
            if (!isActive)
            {

                if (text == null || text.Length == 0)
                {
                    return;
                }
                
                playerMovementScript.Freeze();
                dialogueBox.SetActive(true);
                isActive = true;
                index = 0;

                // types the first line
                StartCoroutine(TypeLine());
            }
            else
            {
                if (isTyping)
                {
                    StopAllCoroutines();
                    textComponent.text = text[index];
                    isTyping = false;
                }
                else
                {
                    index++;
                    if (index < text.Length)
                    {
                        // types the next line
                        textComponent.text = string.Empty;
                        StartCoroutine(TypeLine());
                    }
                    else
                    {
                        dialogueBox.SetActive(false);
                        isActive = false;
                        index = 0;
                        playerMovementScript.UnFreeze();
                    }
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char c in text[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flavor Text"))
        {
            isTouching = true;
            FlavorText ft = collision.gameObject.GetComponent<FlavorText>();
            text = ft.lines;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flavor Text"))
        {
            isTouching = false;
            textComponent.text = string.Empty;
        }
    }
}