using UnityEngine;


public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    //public GameObject puzzle2updater;

    /*public static bool hasKeyBedroom = false;
    public static bool hasKeyMRoom = false;
    public static bool hasEyeball = false;
    public static int eyeballCount = 0;
    public static bool hasKnife = false;
    public static int knifeCount = 0;*/

    public static int eyeballCount = 0;
    public int knifeCount = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
    }


    public bool AddItem(string item)
    {
        Transform enableItemUI = inventoryPanel.transform.Find(item);
        //Debug.Log(enableItemUI.name);
        if (enableItemUI != null)
        {
            if (enableItemUI.gameObject.activeSelf == false)
            {
                Debug.Log("added " + enableItemUI.name);
                enableItemUI.gameObject.SetActive(true);
            }

            if (item == "Knife")
            {
                knifeCount++;
                Debug.Log("added one more " + enableItemUI.name + " (" + knifeCount + ")");
            }
            if (item == "Eyeball")
            {
                eyeballCount++;
                Debug.Log("added one more " + enableItemUI.name + " (" + eyeballCount + ")");
            }

            return true;
        }

        Debug.Log("Cannot add item " + item);
        return false;
    }

    public void RemoveItem(string item)
    {
        Transform disableItemUI = inventoryPanel.transform.Find(item);
        if (disableItemUI != null)
        {
            Debug.Log("Removed " + item);
            disableItemUI.gameObject.SetActive(false);
            //return true;
        }
        Debug.Log("Cannot remove item " + item);
        //return false;
    }

    public bool HasItem(string item)
    {
        Transform itemTransform = inventoryPanel.transform.Find(item);
        if (itemTransform != null && itemTransform.gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }

}