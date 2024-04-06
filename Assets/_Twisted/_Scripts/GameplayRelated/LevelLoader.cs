using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("levelnumber", 1) > SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("levelnumber", 1));
        }
    }
}
