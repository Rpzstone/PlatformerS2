using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {

        Screen.SetResolution(1920, 1080, true);



    }
}
