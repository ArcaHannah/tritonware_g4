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
    private Collider2D collectibleItemCollider;

    public PuzzleInfo info;
    public InventoryController inventoryController;
    public FlavorText ft;
    public bool collectedKey = false;
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
        else if (inventoryController.HasItem("Key") && collectedKey == false && (collectibleItemCollider != null))
        {
            transform.Find("Eyeball").gameObject.SetActive(true);
            collectedKey = true;
            ft.lines[0] = "* The lock unlatches, and you open the drawer.\n* Something unsickly writhes at the bottom.";
            ft.lines[1] = "* The eyeball flails in your hand, the pupil scanning the room in a frenzy.";
        }
        
        // if E is pressed
        if (bedroomEyeball == false && Input.GetKeyDown(KeyCode.E) && collectedKey == true && (collectibleItemCollider != null))
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
        GetComponent<FlavorText>().enabled = true;
        SendMessage("SetComplete");
        info.isComplete = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        collectibleItemCollider = collision.collider;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collectibleItemCollider = null;
    }


}
