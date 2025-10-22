using TMPro;
using UnityEngine;

public class DisplayVariableEyeball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public TMP_Text counterText;
   public InventoryController inventoryController;

   public void Update()
    {
        if (inventoryController.eyeballCount > 1)
        {
            counterText.text = inventoryController.eyeballCount.ToString();
        }
   }
}
