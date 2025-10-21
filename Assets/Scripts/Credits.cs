using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    bool haveCreditsStarted = false;
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
    void Update()
    {
        if (haveCreditsStarted)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                credits.SetActive(false);
                thankYou.SetActive(true);
                mainMenuButton.SetActive(true);
                haveCreditsStarted = false;
            }
        }
    }
    
    void StartCredits()
    {
        haveCreditsStarted = true;
        credits.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
