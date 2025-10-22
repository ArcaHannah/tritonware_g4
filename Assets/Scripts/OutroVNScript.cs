using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.XR.OpenVR;
using System;

public class OutroVNScript : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject background4;

    public GameObject mcCG;
    public GameObject shadowCG;
    public int moveDistance;
    public int moveIterations;
    public float moveDelay;
    
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI continueText;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        background1.SetActive(true);
        background2.SetActive(false);
        background3.SetActive(false);
        background4.SetActive(false);

        shadowCG.SetActive(false);

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;

            if (index == 0 || index == 1)
            {
                textComponent.color = Color.white;
            }
            else
            {
                textComponent.color = Color.red;
            }


            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            UpdateBackground();
            UpdateCG();
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            background4.SetActive(false);
            SendMessage("StartCredits");
        }
    }

    void UpdateBackground()
    {
        if (index == 3)
        {
            background1.SetActive(false);
            background2.SetActive(true);

            continueText.gameObject.SetActive(false);
            dialogueBox.SetActive(false);
        }
        else if (index == 4)
        {
            background2.SetActive(false);
            background3.SetActive(true);
        }
        else if (index == 5)
        {
            background3.SetActive(false);
            background4.SetActive(true);
        }
        else if (index == 6)
        {
            dialogueBox.SetActive(true);
            continueText.gameObject.SetActive(true);
        }
    }

    void UpdateCG()
    {
        switch (index)
        {
            case 0:
                shadowCG.SetActive(false);
                break;
            case 2:
                mcCG.SetActive(false);
                shadowCG.SetActive(true);
                break;
            case 3:
                shadowCG.SetActive(false);
                break;
            case 6:
                mcCG.SetActive(true);
                shadowCG.SetActive(true);
                StartCoroutine(PlotTwist());
                break;
            case 8:
                mcCG.SetActive(false);
                break;
        }
    }

    IEnumerator PlotTwist()
    {
        for (int i = 0; i < moveIterations; i++)
        {
            shadowCG.transform.position += new Vector3(-moveDistance, 0, 0);
            yield return new WaitForSeconds(moveDelay);
        }

        shadowCG.SetActive(false);
    }
}
