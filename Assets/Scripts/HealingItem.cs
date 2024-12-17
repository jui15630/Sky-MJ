using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public GameObject effectPrefab;
    private PlayerHealth playerHealth;
    private int reward = 1;

    void Start()
    {
        // 「Player」についている「PlayerHealth」スクリプトにアクセスする。
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレーヤーのShellで破壊するとHPが回復する
        if (other.gameObject.CompareTag("Shell"))
        {
            

            // アイテムを画面から消す（破壊する）
            Destroy(this.gameObject);

            // プレーヤーのHPを自分が指定した量だけ回復させる
            playerHealth.AddHP(reward);
        }
    }
}