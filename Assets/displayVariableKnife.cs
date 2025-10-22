using UnityEngine;
using TMPro;

public class displayVariableKnife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public TMP_Text counterText;
   public InventoryController inventoryController;

   public void Update()
    {
        if (inventoryController.knifeCount > 1)
        {
            counterText.text = inventoryController.knifeCount.ToString();
        }
        else
        {
            counterText.text = "";
        }
   }
}

