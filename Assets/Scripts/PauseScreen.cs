using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private Canvas pauseScreen;
    private float lastTimeEscPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        pauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GetTimeSinceEscapeLastPressed() > 0.1)
        {
            pauseScreen.enabled = !pauseScreen.enabled;
            lastTimeEscPressed = Time.time;
        }
    }

    private float GetTimeSinceEscapeLastPressed()
    {
        return Time.time - lastTimeEscPressed;
    }
}
