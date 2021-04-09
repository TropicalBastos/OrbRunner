using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Text score;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        score = transform.Find("Score").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + player.GetScore().ToString();
    }
}
