using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1LockCopy : MonoBehaviour
{
    public GameObject colorLock;
    
    // the 4 color lock inputs
    public Image color1;
    public Image color2;
    public Image color3;
    public Image color4;
    
    
    static Color red = Color.red;
    static Color green = Color.green;
    static Color blue = Color.blue;
    static Color yellow = Color.yellow;

    Color[] currentCombo;
    /*public Color[] correctCombo = new Color[4]
    {
        
    }*/

    static Dictionary<int, Color> colors = new Dictionary<int, Color>()
    {
        { 0, red },
        { 1, green },
        { 2, blue },
        { 3, yellow },
    };

    private int index = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        color1.color = red;
        color2.color = red;
        color3.color = red;
        color4.color = red;
        //colorLock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpButton(Image colorSlot)
    {
        if (index == colors.Count - 1)
        {
            index = -1;
        }

        colorSlot.color = colors[index + 1];
        index++;
    }

    public void DownButton(Image colorSlot)
    {
        if (index == 0)
        {
            index = colors.Count;
        }

        colorSlot.color = colors[index - 1];
        index--;
    }
    
    void PuzzleComplete()
    {
        colorLock.SetActive(false);
    }
}
