using UnityEngine;
using TMPro;

public class Puzzle1Input : MonoBehaviour
{
    private int index = 0;
    public TMP_Text slot;

    int[] nums = new int[10]
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    };
    
    public void UpButton()
    {
        if (index == nums.Length - 1)
        {
            index = -1;
        }

        slot.text = nums[++index].ToString();
    }

    public void DownButton()
    {
        if (index == 0)
        {
            index = nums.Length;
        }
        
        slot.text = nums[--index].ToString();
    }
}
