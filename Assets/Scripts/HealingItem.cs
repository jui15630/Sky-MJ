using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // プレーヤーのShellで破壊された場合
        if (other.gameObject.CompareTag("Shell"))
        {
            // プレーヤーのGameObjectを取得
            GameObject player = other.transform.root.gameObject;

            // PlayerHealthを取得
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // プレイヤーのHPを回復
                playerHealth.HealHP(1);
            }

            // アイテムを画面から消す（破壊する）
            Destroy(this.gameObject);
        }
    }
}