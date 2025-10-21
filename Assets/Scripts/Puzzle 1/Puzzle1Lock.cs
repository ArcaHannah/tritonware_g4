using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using NUnit.Framework;
using Unity.VisualScripting;
using System.Collections;

public class Puzzle1Lock : MonoBehaviour
{
    public GameObject lockUI;
    
    // the 4 color lock inputs
    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;
    public TMP_Text slot4;

    public PuzzleInfo info;
    public InventoryController inventoryController;
    public FlavorText ft;
    private bool hasKey = false;
    private bool bedroomEyeball = false;


    public int[] currentCombo = new int[4];
    public int[] correctCombo = new int[4];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < correctCombo.Length; i++)
        {
            correctCombo[i] = UnityEngine.Random.Range(0, 10);
            Debug.Log($"Index {i}: {correctCombo[i]}"); // Optional: Log each generated number
        }
        slot1.text = "0";
        slot2.text = "0";
        slot3.text = "0";
        slot4.text = "0";
        info = GetComponent<PuzzleInfo>();
        lockUI.SetActive(false);
        ft = this.GetComponent<FlavorText>();
        ft.lines[0] = "* You heard a clicking noise, but the lock's not budging.";
        ft.lines[1] = "* Turning the lock in your hand reveals a keyhole.";
    }

    // Update is called once per frame
    void Update()
    {
        if (!info.isComplete)
        {
            currentCombo[0] = Int32.Parse(slot1.text);
            currentCombo[1] = Int32.Parse(slot2.text);
            currentCombo[2] = Int32.Parse(slot3.text);
            currentCombo[3] = Int32.Parse(slot4.text);

            if (currentCombo[0] == correctCombo[0] && currentCombo[1] == correctCombo[1] &&
                currentCombo[2] == correctCombo[2] && currentCombo[3] == correctCombo[3])
            {
                PuzzleComplete();
            }
        }
        else if (hasKey == false && inventoryController.HasItem("Key"))
        {
            transform.Find("Eyeball").gameObject.SetActive(true);
            ft.lines[0] = "* The lock unlatches, and you open the drawer.\n* Something unsickly writhes at the bottom.";
            ft.lines[1] = "* The eyeball flails in your hand, the pupil scanning the room in a frenzy.";
            hasKey = true; // this boolean is so that this else if block only runs once when the player has key
        }
        else if (bedroomEyeball == false && inventoryController.HasItem("Eyeball"))
        {
            inventoryController.RemoveItem("Key");
            bedroomEyeball = true;
        }
        
    }

    public void CloseButton()
    {
        lockUI.SetActive(false);
    }

    void PuzzleComplete()
    {
        lockUI.SetActive(false);
        tag = "Flavor Text";
        if (inventoryController.HasItem("Key") == false)
        {
            Debug.Log("YOU DO NOT HAVE THE KEY..");
            GetComponent<FlavorText>().enabled = true;
        }
        else //OK I KNOW THIS IS SPAGHETTI CODE BUT IVE BEEN WORKING ON THIS PUZZLE FOR LIKE 3 DAYS
        {
            inventoryController.RemoveItem("Key");
            transform.Find("Eyeball").gameObject.SetActive(true);
            ft.lines[0] = "* The lock unlatches, and you open the drawer.\n* Something unsickly writhes at the bottom.";
            ft.lines[1] = "* The eyeball flails in your hand, the pupil scanning the room in a frenzy.";
            hasKey = true; // this boolean is so that this else if block only runs once when the player has key
        }
        SendMessage("SetComplete");
        info.isComplete = true;
    }


    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (lockComplete == true)
        {
            if (inventoryController.HasItem("Key") && inventoryController.HasItem("Eyeball") && eyeballDialogueFinished == false)
            {
                inventoryController.RemoveItem("Key");
                
                eyeballDialogueFinished = true;
            }
            else if (eyeballDialogueFinished)
            {
                //ft.lines[0] = "* Ants march along the inside of the drawer from the open snack bags and food containers.";
                //ft.lines[1] = "* You try to recall the last thing you ate.";
                ft.lines[0] = null;
                ft.lines[1] = null;
                GetComponent<FlavorText>().enabled = false;
            }
        }
    }*/

    /*void OnCollisionExit2D(Collision2D collision)
    {
        ft.lines[0] = "";
        ft.lines[1] = "";
    }*/

}
