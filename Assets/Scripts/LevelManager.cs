using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public void LoadNext()
    {
        SceneManager.LoadScene("Level 2");
        Debug.Log("Button");
    }
}
