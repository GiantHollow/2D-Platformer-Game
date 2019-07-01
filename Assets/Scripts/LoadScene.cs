using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        ScoreScript.scoreValue = 0;
        LifesScript.lifeValue = 2;
    }
}
