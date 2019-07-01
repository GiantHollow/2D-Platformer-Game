using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public Text score;

    // Use this for initialization
    void Awake()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = "Score: " + scoreValue;
    }
}
