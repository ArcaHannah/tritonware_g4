using System.Collections.Generic;
using UnityEngine;

public class puzzle2scripttest : MonoBehaviour
{

    public static int numKnives = 4;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //erm
    }

    void Update()
    {
        /*for (int i = numKnives;  knifeCount == 0; knifeCount--)
        {
            
        }*/
    }
    
    // updates the number of knives and returns the number of knives left
    int UpdateKnifeCount(int knifeCount)
    {
        knifeCount = numKnives - knifeCount;
        return knifeCount;
    }


}
