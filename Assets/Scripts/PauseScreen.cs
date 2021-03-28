using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private Canvas pauseScreen;
    private Button resumeButton;
    private Button quitButton;
    private float lastTimeEscPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        pauseScreen.enabled = false;
        resumeButton.onClick.AddListener(OnResumeClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GetTimeSinceEscapeLastPressed() > 0.1)
        {
            pauseScreen.enabled = !pauseScreen.enabled;
            lastTimeEscPressed = Time.time;

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
        Application.Quit();
    }

    private void OnResumeClicked()
    {
        Time.timeScale = 1;
        pauseScreen.enabled = false;
    }

    private float GetTimeSinceEscapeLastPressed()
    {
        return Time.time - lastTimeEscPressed;
    }
}
