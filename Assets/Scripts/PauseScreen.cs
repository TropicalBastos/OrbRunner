using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    private Canvas pauseScreen;
    private Button resumeButton;
    private Button restartButton;
    private Button quitButton;
    private Text score;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        score = GameObject.Find("PauseScore").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<Player>();

        pauseScreen.enabled = false;
        resumeButton.onClick.AddListener(OnResumeClicked);
        restartButton.onClick.AddListener(OnRestartClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score
        score.text = "SCORE: " + player.GetScore();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.enabled = !pauseScreen.enabled;

            if (pauseScreen.enabled) 
            {
                Time.timeScale = 0;
            } 
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    private void OnQuitClicked()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void OnRestartClicked()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void OnResumeClicked()
    {
        Time.timeScale = 1;
        pauseScreen.enabled = false;
    }
}
