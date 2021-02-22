using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
   

    public void restartScene()
    {
        ScoreScript.scoreValue =0;
        SceneManager.LoadScene("BasicMovementAndAnim");
    }
}
