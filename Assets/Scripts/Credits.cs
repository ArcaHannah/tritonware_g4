using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject credits;
    public GameObject thankYou;
    public GameObject mainMenuButton;

    void Start()
    {
        credits.SetActive(false);
        thankYou.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (haveCreditsStarted)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                haveCreditsStarted = false;
                wereCreditsSeen = true;
            }
        }
        else if (wereCreditsSeen)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                
                wereCreditsSeen = false;
                Debug.Log("credits ended");
            }
        }
    }*/

    void StartCredits()
    {
        credits.SetActive(true);
        StartCoroutine(RollCredits());
    }

    IEnumerator RollCredits()
    {
        yield return new WaitForSeconds(3);

        credits.SetActive(false);
        thankYou.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
