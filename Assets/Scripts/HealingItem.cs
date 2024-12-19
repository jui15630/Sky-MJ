using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // ÉvÉåÅ[ÉÑÅ[ÇÃShellÇ≈îjâÛÇ≥ÇÍÇΩèÍçá
        if (other.gameObject.CompareTag("Shell"))
        {
            GameObject player = other.transform.root.gameObject;

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.HealHP(1);
            }

            Destroy(this.gameObject);
        }
    }
}