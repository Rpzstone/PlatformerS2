using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerBoss : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
