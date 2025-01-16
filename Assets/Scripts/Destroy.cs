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
            Destroy(objectText);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer > detectionRange)
        {
            objectText.gameObject.SetActive(false);
            Debug.Log("�I�u�W�F�N�g�����m���Ă��܂���");
        }
        else if (distanceToPlayer < detectionRange)
        {
            objectText.gameObject.SetActive(true);
            Debug.Log("�I�u�W�F�N�g�����m");
        }
    }
}
