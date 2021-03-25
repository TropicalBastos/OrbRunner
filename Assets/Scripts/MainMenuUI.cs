using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject startButtonGO = GameObject.Find("StartButton");
        Button startButton = startButtonGO.GetComponent<Button>();
        Text text = startButton.GetComponentInChildren<Text>();
        text.text = "START";
        text.color = new Color(255, 255, 255);
        text.fontSize = 40;
        startButton.onClick.AddListener(OnStartClick);
    }

    void OnStartClick() 
    {
        SceneManager.LoadScene("Game");
    }
}
