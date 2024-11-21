using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour
{
    private void Start()
    {
        // �R���e�B�j���[�V�[���ł̓J�[�\����\��
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;  // �^�C���X�P�[�������ɖ߂�
        SceneManager.LoadScene("MainScene");  // ���C���V�[�����ăX�^�[�g
    }

    public void QuitGame()
    {
        Application.Quit();  // �Q�[�����I��
    }

}
