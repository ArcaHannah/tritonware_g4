using TMPro;
using UnityEngine;

public class DisplayVariableEyeball : InventoryController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public TMP_Text counterText;
   public InventoryController inventoryController;

   public void Update()
    {
        if (eyeballCount > 1)
        {
            counterText.text = eyeballCount.ToString();
        }
   }
}
