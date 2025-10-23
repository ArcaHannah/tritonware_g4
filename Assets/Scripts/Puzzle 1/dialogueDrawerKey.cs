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
            if ((updatedDialogue == false) && (bedroomDrawer.GetComponent<InventoryController>().HasItem("Key") == true || bedroomDrawer.GetComponent<Puzzle1Lock>().collectedKey == true))
            {
                ftDrawer.lines[0] = "* It's a photo of your mother and you.\n* It's the only one you have.";
                updatedDialogue = true;
            }
        }
    }



}
