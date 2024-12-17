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
        // �uPlayer�v�ɂ��Ă���uPlayerHealth�v�X�N���v�g�ɃA�N�Z�X����B
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���[���[��Shell�Ŕj�󂷂��HP���񕜂���
        if (other.gameObject.CompareTag("Shell"))
        {
            

            // �A�C�e������ʂ�������i�j�󂷂�j
            Destroy(this.gameObject);

            // �v���[���[��HP���������w�肵���ʂ����񕜂�����
            playerHealth.AddHP(reward);
        }
    }
}