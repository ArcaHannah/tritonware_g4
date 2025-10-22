using UnityEngine;

public class hubChange : MonoBehaviour
{
    public bool hubPhaseTwo = false;
    public GameObject unveiledHubRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unveiledHubRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((hubPhaseTwo == false) && InventoryController.eyeballCount == 3)
        {
            unveiledHubRef.SetActive(true);
            this.gameObject.SetActive(false);
            hubPhaseTwo = true;
        }
    }
}
