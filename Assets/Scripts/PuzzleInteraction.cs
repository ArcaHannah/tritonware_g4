using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleInteraction : MonoBehaviour
{
    public GameObject puzzleUI;
    public bool isTouching = false;
    PuzzleInfo puzzleInfo;

    void Update()
    {
        if (puzzleInfo != null && !puzzleInfo.isComplete)
        {
            if (Input.GetKeyDown(KeyCode.E) && isTouching && puzzleUI != null)
            {
                puzzleUI.SetActive(true);
            }
        }
        else
        {
            puzzleInfo = null; // disable puzzleInfo
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isTouching = true;

        if (collision.gameObject.tag == "Puzzle" && puzzleUI == null)
        {
            puzzleInfo = collision.gameObject.GetComponent<PuzzleInfo>();
            puzzleUI = puzzleInfo.puzzleUI;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isTouching = false;
        
        if (collision.gameObject.tag == "Puzzle")
        {
            puzzleUI.SetActive(false);
            puzzleUI = null;
        }
    }
}
