using System.Collections.Generic;
using UnityEngine;

public class puzzle1scripttest : MonoBehaviour
{
    private static Dictionary<string, int> colorScreens = new Dictionary<string, int>()
    {
        {"Red", 1},
        {"Blue", 4},
        {"Green", 1},
        {"Yellow", 3}
    };
    public bool puzzleActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PSUEDOCODE!!
        /*while (puzzleActive) {
            while (activeColor != null) {
                for colorScrreen value {
                    tv.setActive(color screen, true);
                    wait(3)
                    tv.setActive(color screen, false);
                    wait(1)
                }
                wait(3)
                activeColor++;
            }
            wait(5)
            activeColor set 0 // go restart the color looping back to beginning
        }*/
        // screen will not run through the flashing lights script if puzzle is inactive


    }


}
