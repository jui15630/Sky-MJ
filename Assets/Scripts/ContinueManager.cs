using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour
{
    private void Start()
    {
        // コンティニューシーンではカーソルを表示
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;  // タイムスケールを元に戻す
        SceneManager.LoadScene("MainScene");  // メインシーンを再スタート
    }

    public void QuitGame()
    {
        Application.Quit();  // ゲームを終了
    }

}
