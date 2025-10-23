using System;
using TMPro;
using UnityEngine;

public class Puzzle3Lock : MonoBehaviour
{
    public GameObject lockUI;
    
    // the 4 color lock inputs
    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;

    public PuzzleInfo info;
    public InventoryController inventoryController;
    public FlavorText ft;
    


    public int[] currentCombo = new int[3];
    public int[] correctCombo = {5, 2, 2};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        info = GetComponent<PuzzleInfo>();
        lockUI.SetActive(false);
        ft = this.GetComponent<FlavorText>();
        ft.lines[0] = "* The face of the clock is now open. There's nothing inside.";
        ft.lines[1] = "* You feel the eyeball squirm in your front pocket.";
    }

    // Update is called once per frame
    void Update()
    {
        if (!info.isComplete)
        {
            currentCombo[0] = Int32.Parse(slot1.text);
            currentCombo[1] = Int32.Parse(slot2.text);
            currentCombo[2] = Int32.Parse(slot3.text);

            if (currentCombo[0] == correctCombo[0] && currentCombo[1] == correctCombo[1] &&
                currentCombo[2] == correctCombo[2])
            {
                PuzzleComplete();
                inventoryController.AddItem("Eyeball");
            }
        }
        else
        {
            // dont delete this block
        }
    }

    void PuzzleComplete()
    {
        lockUI.SetActive(false);
        tag = "Flavor Text";
        GetComponent<FlavorText>().enabled = true;
        SendMessage("SetComplete");
        info.isComplete = true;
    }
    
    public void CloseButton()
    {
        lockUI.SetActive(false);
    }
}
