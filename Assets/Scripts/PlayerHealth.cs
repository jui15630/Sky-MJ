using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager GameManager;
    public int maxHealth = 2;
    public int currentHealth;
    public Image[] healthImages;             // �v���C���[�̃w���X�����o�I�Ɏ����C���[�W�摜
    public float invincibilityDuration = 5f; // ���G��Ԃ̌p������

    private bool isInvincible = false;       // ���G��Ԃ��ǂ����������t���O
    private float invincibilityTimer = 0f;   // ���G��Ԃ̃^�C�}�[

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        // ���G��Ԃ̂Ƃ��̓^�C�}�[��i�߂�
        if (isInvincible)
        {
            invincibilityTimer += Time.deltaTime;
            if (invincibilityTimer >= invincibilityDuration)
            {
                isInvincible = false;
                invincibilityTimer = 0f;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isInvincible)
        {
            currentHealth -= amount;
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                GameManager.GameOver();
            }

            // ���G��Ԃɂ���
            isInvincible = true;
        }
    }

    void UpdateHealthUI()
    {
        // �v���C���[�̃w���X�ɉ����ăC���[�W�摜���X�V
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].enabled = true; // �C���[�W��\��
            }
            else
            {
                healthImages[i].enabled = false; // �C���[�W���\��
            }
        }
    }
    public void HealHP(int amount)
    {
        currentHealth += amount;

        // �ő�HP�ȏ�ɂ͉񕜂��Ȃ��悤�ɂ���B
        if (currentHealth > 2)
        {
            currentHealth = 2;
        }

        
    }
}
