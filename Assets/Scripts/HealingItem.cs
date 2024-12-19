using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // �v���[���[��Shell�Ŕj�󂳂ꂽ�ꍇ
        if (other.gameObject.CompareTag("Shell"))
        {
            // �v���[���[��GameObject���擾
            GameObject player = other.transform.root.gameObject;

            // PlayerHealth���擾
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // �v���C���[��HP����
                playerHealth.HealHP(1);
            }

            // �A�C�e������ʂ�������i�j�󂷂�j
            Destroy(this.gameObject);
        }
    }
}