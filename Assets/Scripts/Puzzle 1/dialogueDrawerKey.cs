using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class dialogueDrawerKey : MonoBehaviour
{
    public GameObject bedroomDrawer;
    FlavorText ftDrawer;
    //public InventoryController inventoryController;
    //public FlavorTextHandler handlerCheck;
    //public GameObject dialogueBox;
    public bool updatedDialogue;
    //private bool isHandlingInteraction = false;
    void Start()
    {
        updatedDialogue = false;
        ftDrawer = this.GetComponent<FlavorText>();
    }

    /*void Update()
    {
        if ((updatedDialogue == false) && inventoryController.HasItem("Key"))
        {
            ft.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
            updatedDialogue = true;
        }
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PhotoDrawer")
        {
            if ((updatedDialogue == false) && bedroomDrawer.GetComponent<InventoryController>().HasItem("Key"))
            {
                ftDrawer.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
                updatedDialogue = true;
            }
        }
    }


    /*void OnCollisionStay2D(Collision2D collision)
    {
        if (!isHandlingInteraction && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(HandleInteraction());
        }
    }

    IEnumerator HandleInteraction()
    {
        isHandlingInteraction = true;

        if (!firstDialogueRead)
        {
            firstDialogueRead = true;
            
            yield return StartCoroutine(WaitForHandlerCoroutine()); 
            
            toAddKey.AddItem("Key"); 
        }
        else
        {
            ft.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
            ft.lines[1] = "";
            ft.lines[2] = "";
            
            yield return StartCoroutine(WaitForHandlerCoroutine());
        }

        isHandlingInteraction = false;
    }

    IEnumerator WaitForHandlerCoroutine()
    {
        yield return new WaitUntil(() => handlerCheck.isActive == false);
    }
}*/

    /*void OnCollisionStay2D(Collision2D collision)
    {
        if (toAddKey.inventoryPanel.transform.Find("Key") == true && (updatedDialogue = false))
        {
            ft.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
            updatedDialogue = true;
            /*Debug.Log("ITS FALSE!!!");
            if (handlerCheck.isActive)
            {
                Debug.Log("dialogue box open");
                firstDialogueRead = true;
                Debug.Log("TRUTH NUKE!!");
                toAddKey.AddItem("Key");
            }*/
        //}
        /*else
        {
            ft.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
            Debug.Log("SUBSEQUENTIAL TRUTH NUKE!!");
        }
        /*if (firstDialogueRead == false && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("STARTED FIRST DIALOGUE!!!");
            StartCoroutine(waitForHandler());
        }*/
    //}
    /*void OnCollisionExit2D(Collision2D collision)
    {
        if (handlerCheck.isActive == false)
        {
            Debug.Log("Left the drawer");
            StopAllCoroutines();
        }
    }*/
    

    //IEnumerator waitForHandler()
    //{
        /*while (handlerCheck.isActive)
        {
            yield return null;
        }*/
        /*yield return null;
        yield return new WaitUntil(() => handlerCheck.isActive == true);
        Debug.Log("Waiting for dialogue to get pressed");
        yield return new WaitUntil(() => handlerCheck.isActive == false);
        Debug.Log("Dialogue over");
        toAddKey.AddItem("Key");
        firstDialogueRead = true;
        ft.lines[0] = "* It's a photo of your mother and you.\n*  It's the only one you have.";
    }*/



}
