using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void RestartSceneMethod()
    {
        Debug.Log(SceneManager.GetActiveScene().ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

