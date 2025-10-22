using System.Collections.Generic;
using UnityEngine;

public class puzzle2scripttest : InventoryController
{

    // true number of knives player has to collect for the puzzle
    public static int knivesLeft = 3; // there are actually three and not four because boy genius used the last one
    //private int totalKnifeCounter = 0; // used for dialogue update dont worry
    public InventoryController inventoryController;
    private bool isComplete = false;
    public FlavorText ft;
    private Collider2D collectibleItemCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ft = this.GetComponent<FlavorText>();
        ft.lines[0] = "There are " + (knivesLeft + 1) + " empty slots in the knife block.";
    }

    void Update()
    {
        if ((isComplete == false) && (collectibleItemCollider != null))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inventoryController.HasItem("Knife"))
                {
                    UpdatePuzzleTwo();
                }
            }
        }
    }


    // updates the number of knives
    void UpdatePuzzleTwo()
    {
        inventoryController.knifeCount = knivesLeft - inventoryController.knifeCount;
        inventoryController.RemoveItem("Knife");
        if (knivesLeft == 0)
        {
            eyeballCount++;
            isComplete = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KnifePuzzle"))
        {
            collectibleItemCollider = collision.collider;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KnifePuzzle") && collision.collider == collectibleItemCollider)
        {
            collectibleItemCollider = null;
        }
    }



}
