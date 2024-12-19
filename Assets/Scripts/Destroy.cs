using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float detectionRange;
    [SerializeField] private GameObject textPrefab;
    private GameObject objectTextInstance;

    private bool isObjectVisible = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            GameManager.Instance.TargetDestroyed();
            Destroy(textPrefab);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer > detectionRange)
        {
            if (textPrefab.activeSelf) textPrefab.SetActive(false);
        }
        else
        {
            if (!textPrefab.activeSelf) textPrefab.SetActive(true);
        }


    }

}
