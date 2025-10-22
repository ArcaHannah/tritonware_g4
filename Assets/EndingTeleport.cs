using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTeleport : MonoBehaviour
{
    private Collider2D collectibleItemCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player is touching an item
        if (collectibleItemCollider != null)
        {
            // if E is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("EndingVN");
            }
        }
    }

    // when the player is touching an item
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collectibleItemCollider = collision.collider;
    }
        private void OnCollisionExit2D(Collision2D collision)
    {
        collectibleItemCollider = null;
    }

}
