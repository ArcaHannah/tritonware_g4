// ADD THIS SCRIPT TO EVERY OBJECT THAT OPENS A PUZZLE UI (e.g. a lock)

using UnityEngine;

public class PuzzleInfo : MonoBehaviour
{
    public GameObject puzzleUI;
    public bool isComplete = false;

    // can be used to set whether or not a puzzle is complete
    void SetComplete()
    {
        isComplete = true;
    }
}
