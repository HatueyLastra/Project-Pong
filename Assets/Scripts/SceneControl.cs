using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void OptionMultiPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionSinglePlayer()
    {
        SceneManager.LoadScene(2);
    }
}
