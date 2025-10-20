using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using NUnit.Framework;

public class Puzzle1Lock : MonoBehaviour
{
    public GameObject lockUI;
    
    // the 4 color lock inputs
    public TMP_Text slot1;
    public TMP_Text slot2;
    public TMP_Text slot3;
    public TMP_Text slot4;

    PuzzleInfo info;


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
    }

    public void CloseButton()
    {
        lockUI.SetActive(false);
    }
    
    void PuzzleComplete()
    {
        lockUI.SetActive(false);
        SendMessage("SetComplete");
    }
}
