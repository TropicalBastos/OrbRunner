using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    void Start()
    {
        GameObject startButtonGO = GameObject.Find("StartButton");
        Button startButton = startButtonGO.GetComponent<Button>();
        startButton.onClick.AddListener(OnStartClick);
        GameObject quitButtonGO = GameObject.Find("QuitButton");
        Button quitButton = startButtonGO.GetComponent<Button>();
        quitButton.onClick.AddListener(OnQuitClick);
        Text highscore = GameObject.Find("Highscore").GetComponent<Text>();

        if (PlayerPrefs.HasKey("Score"))
        {
            highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Score");
        } 
        else
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    void OnStartClick() 
    {
        SceneManager.LoadScene("Game");
    }

    void OnQuitClick() 
    {
        Application.Quit();
    }
}
