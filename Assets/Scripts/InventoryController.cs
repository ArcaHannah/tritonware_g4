using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;

    public static bool hasKey = false;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            if (i < itemPrefabs.Length)
            {
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = item;
            }
        }

    }
    
    public bool AddItem(GameObject itemPrefab)
    {
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                //Transform itemTransform = newItem.transform;
                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                if (rectTransform != null)
            {
                rectTransform.localScale = Vector3.one;       // Reset scale (important for UI parenting)
                rectTransform.anchoredPosition = Vector2.zero; // Center the item in the slot
            }
                slot.currentItem = newItem;
                //newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                return true;
            }
        }
        Debug.Log("Cannot add item");
        return false;
    }

}
