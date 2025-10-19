using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
private InventoryController inventoryController;
    private Collider2D collectibleItemCollider = null;

    //[SerializeField]
    //private GameObject interactionMessage;

    void Start()
    {
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    // Called once per frame
    void Update()
    {
        // disable interaction message by default
        //interactionMessage.SetActive(false);

        // if player is touching an item
        if (collectibleItemCollider != null)
        {
            // enable message telling player to hit E
            //interactionMessage.SetActive(true);

            // if E is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                bool itemAdded = inventoryController.AddItem(collectibleItemCollider.gameObject);
                if (itemAdded)
                {
                    // makes reference to the item about to be collected
                    GameObject collectedGameObject = collectibleItemCollider.gameObject;
                    collectibleItemCollider = null; // clears item reference
                    Destroy(collectedGameObject);
                }
            }
        }
    }

    // when the player is touching an item
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // gets info on what item the player colliding with
            collectibleItemCollider = collision.collider;
        }
    }

    // when the player stops touching the item
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item") && collision.collider == collectibleItemCollider)
        {
            collectibleItemCollider = null;
        }
    }

    /*private InventoryController inventoryController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            GameObject item = collision.GetComponent<GameObject>();
            if (item != null && Input.GetKeyDown(KeyCode.E))
            {
                bool itemAdded = inventoryController.AddItem(collision.gameObject);
                if (itemAdded)
                {
                    Destroy(collision.gameObject);
                }
                
                
            }
        }
    }*/
}
