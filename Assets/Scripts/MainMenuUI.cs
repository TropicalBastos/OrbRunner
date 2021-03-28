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
        startButton.onClick.AddListener(OnStartClick);
    }

    void OnStartClick() 
    {
        SceneManager.LoadScene("Game");
    }
}
