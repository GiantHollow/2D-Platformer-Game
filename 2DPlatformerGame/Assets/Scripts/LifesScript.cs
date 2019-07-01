using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesScript : MonoBehaviour {

    public static int lifeValue = 2;
    public Text score;

    // Use this for initialization
    void Awake()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = "Lifes: " + lifeValue;
    }
}
