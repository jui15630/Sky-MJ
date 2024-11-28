using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance { get; private set; }
    private int totalTargets;
    private int destroyedTargets;
    private float timer;
    private bool gameEnded;

    public TextMeshProUGUI clearText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI remainingTargetsText;
    public float gameDuration = 300f; // 5���i300�b�j

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // �V�[�����ύX���ꂽ�Ƃ��̃C�x���g���X�i�[��ǉ�
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        destroyedTargets = 0;
        timer = gameDuration;
        gameEnded = false;

        if (clearText != null)
        {
            clearText.gameObject.SetActive(false);  // �Q�[���J�n���ɃN���A�e�L�X�g���\���ɂ���
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);  // �Q�[���J�n���ɃQ�[���I�[�o�[�e�L�X�g���\���ɂ���
        }

        UpdateTimerText();  // �����^�C�}�[�̕\��
        UpdateRemainingTargetsText(); // �����c��^�[�Q�b�g���̕\��
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                GameOver();
            }

            UpdateTimerText();
        }

        if (gameEnded && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
        else if (gameEnded && Input.GetMouseButtonDown(1))
        {
            QuitGame();
        }
    }

    public void TargetDestroyed()
    {
        if (!gameEnded)
        {
            destroyedTargets++;
            UpdateRemainingTargetsText();

            if (destroyedTargets >= totalTargets)
            {
                GameClear();
            }
        }
    }

    private void GameClear()
    {
        Debug.Log("Game Clear!");
        gameEnded = true;

        if (clearText != null)
        {
            clearText.gameObject.SetActive(true);
        }

        Time.timeScale = 0; // �Q�[�����~����
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameEnded = true;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        Time.timeScale = 0; // �Q�[�����~����

        // �R���e�B�j���[�V�[���Ɉڍs
        SceneManager.LoadScene("ContinueScene");
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void UpdateRemainingTargetsText()
    {
        if (remainingTargetsText != null)
        {
            remainingTargetsText.text = "Targets: " + (totalTargets - destroyedTargets).ToString();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���C���V�[���ȊO�ł̓J�[�\����\��
        if (scene.name != "GameScene")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            InitializeGame();  // ���C���V�[���ɖ߂����ۂɃQ�[����������
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1;  // �^�C���X�P�[�������ɖ߂�
        SceneManager.LoadScene("GameScene");  // ���C���V�[�����ăX�^�[�g
    }

    private void QuitGame()
    {
        Application.Quit();  // �Q�[�����I��
    }
}

