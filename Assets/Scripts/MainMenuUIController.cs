using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        creditsButton.onClick.AddListener(Credits);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PinballGame");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }
}
