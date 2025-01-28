using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScean : MonoBehaviour
{
    public void StartButton()
    {
        Time.timeScale = 1;  // タイムスケールを元に戻す
        SceneManager.LoadScene("GameScene");
    }
}
