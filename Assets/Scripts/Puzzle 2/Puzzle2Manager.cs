using System.Collections.Generic;
using UnityEngine;

public class puzzle2scripttest : MonoBehaviour
{

    // true number of knives player has to collect for the puzzle
    public static int knivesTotal = 3; // there are actually three and not four because boy genius used the last one
    //private int totalKnifeCounter = 0; // used for dialogue update dont worry
    public InventoryController inventoryController;
    private bool isComplete = false;
    public FlavorText ft;
    private Collider2D collectibleItemCollider;
    private bool stopUpdatingKnives = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ft = this.GetComponent<FlavorText>();
        ft.lines[0] = "There are " + (knivesTotal + 1) + " empty slots in the knife block.";
    }

    void Update()
    {
        if ((isComplete == false) && (collectibleItemCollider != null))
        {
            // if E is pressed
            if (Input.GetKeyDown(KeyCode.E) && inventoryController.HasItem("Knife"))
            {
                Debug.Log("We are actually here");
                if (inventoryController.inventoryPanel.transform.Find("Knife").gameObject.activeSelf == true)
                {
                    inventoryController.RemoveItem("Knife");
                }
            }
            if (stopUpdatingKnives == true && inventoryController.HasItem("Eyeball"))
            {
                isComplete = true;
                if (inventoryController.inventoryPanel.transform.Find("Knife").gameObject.activeSelf == true)
                {
                    inventoryController.RemoveItem("Knife");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stopUpdatingKnives == false && inventoryController.knifeCount == knivesTotal)
        {
            transform.Find("Eyeball").gameObject.SetActive(true);
            stopUpdatingKnives = true;
            ft.lines[0] = "* You catch a glimpse of something behind the knife block.\n* You move it, and find an severed eyeball staring straight at you.";
        }
        if (stopUpdatingKnives == false && isComplete == false && inventoryController.HasItem("Knife"))
        {
            ft.lines[0] = "There are " + (knivesTotal - inventoryController.knifeCount + 1) + " empty slots in the knife block.";
        }
        collectibleItemCollider = collision.collider;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collectibleItemCollider = null;
    }



}
