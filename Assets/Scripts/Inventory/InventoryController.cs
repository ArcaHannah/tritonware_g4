using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;

    /*public static bool hasKeyBedroom = false;
    public static bool hasKeyMRoom = false;
    public static bool hasEyeball = false;
    public static int eyeballCount = 0;
    public static bool hasKnife = false;
    public static int knifeCount = 0;*/




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
    }


    public bool AddItem(GameObject item)
    {
        Transform enableItemUI = inventoryPanel.transform.Find(item.name);
        //Debug.Log(enableItemUI.name);
        if (enableItemUI != null)
        {
            enableItemUI.gameObject.SetActive(true);
            return true;
        }
        Debug.Log("Cannot add item " + item.name);
        return false;
    }

    public bool RemoveItem(GameObject item)
    {
        Transform disableItemUI = inventoryPanel.transform.Find(item.name);
        if (disableItemUI != null)
        {
            disableItemUI.gameObject.SetActive(false);
            return true;
        }
        Debug.Log("Cannot remove item " + item.name);
        return false;
    }

}