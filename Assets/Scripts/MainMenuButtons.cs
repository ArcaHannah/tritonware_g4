using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("IntroVN");
    }

}
