using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float detectionRange;
    [SerializeField] private Text objectText;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            GameManager.Instance.TargetDestroyed();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer > detectionRange)
        {
            objectText.gameObject.SetActive(true);
        }
        else
        {
            objectText.gameObject.SetActive(false);
        }
    }
}
