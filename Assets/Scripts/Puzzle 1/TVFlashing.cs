using System.Collections;
using UnityEngine;

public class puzzle1scripttest : MonoBehaviour
{
    private float onTime = 1f;
    private float offTime = 0.5f;
    Puzzle1Lock Puzzle1Code;
    public GameObject tvScreen;
    int[] code;

    void Start()
    {
        Puzzle1Code = GetComponent<Puzzle1Lock>();
        code = Puzzle1Code.correctCombo;

        StartCoroutine(TvFlashSequence());
    }

    void Update()
    {
        if (Puzzle1Code.info.isComplete == true)
        {
            StopAllCoroutines();
            // ensure all screens are off
            foreach (Transform child in tvScreen.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator TvFlashSequence()
    {
        while (Puzzle1Code.info.isComplete == false)
        {
            int activeColorIndex = 0;

            foreach (Transform child in tvScreen.transform)
            {
                if (activeColorIndex >= code.Length)
                {
                    Debug.LogError("more code numbers than color screens...");
                    break;
                }

                for (int i = 0; i < code[activeColorIndex]; i++)
                {
                    child.gameObject.SetActive(true);
                    yield return new WaitForSeconds(onTime);
                    child.gameObject.SetActive(false);
                    yield return new WaitForSeconds(offTime);
                }

                yield return new WaitForSeconds(offTime*2);

                activeColorIndex++;
            }
        }
    }
}
