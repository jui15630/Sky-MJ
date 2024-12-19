using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager GameManager;
    public int maxHealth = 2;
    public int currentHealth;
    public Image[] healthImages;             // プレイヤーのヘルスを視覚的に示すイメージ画像
    public float invincibilityDuration = 5f; // 無敵状態の継続時間

    private bool isInvincible = false;       // 無敵状態かどうかを示すフラグ
    private float invincibilityTimer = 0f;   // 無敵状態のタイマー

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        // 無敵状態のときはタイマーを進める
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

            // 無敵状態にする
            isInvincible = true;
        }
    }

    void UpdateHealthUI()
    {
        // プレイヤーのヘルスに応じてイメージ画像を更新
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].enabled = true; // イメージを表示
            }
            else
            {
                healthImages[i].enabled = false; // イメージを非表示
            }
        }
    }
    public void HealHP(int amount)
    {
        currentHealth += amount;

        // 最大HP以上には回復しないようにする。
        if (currentHealth > 2)
        {
            currentHealth = 2;
        }

        
    }
}
