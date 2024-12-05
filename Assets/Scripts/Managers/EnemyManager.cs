using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private float followDistance = 30.0f;
    [SerializeField] private float wanderRadius = 10.0f;
    [SerializeField] private float wanderTimer = 5.0f;
    [SerializeField] private float fixedYPosition = 2.0f;
    [SerializeField] private int damageAmount = 1; // �v���C���[�ɗ^����_���[�W��   
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private AudioSource bgmSource; // BGM���Đ����邽�߂�AudioSource
    [SerializeField] private AudioClip chaseBGM; // �ǔ����ɍĐ�����BGM
    [SerializeField] private Slider healthSlider; // HP�o�[��Slider
    [SerializeField] private Canvas healthCanvas; // HP�o�[��Canvas

    private NavMeshAgent agent;
    private bool isFollowing = false;
    private float timer;
    private Vector3 wanderTarget;
    private bool isStoppedDueToCollision = false;
    private float stopTimer = 0f;
    private float stopDuration = 5f;
    private int currentHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        wanderTarget = RandomWanderTarget();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (isStoppedDueToCollision)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopDuration)
            {
                isStoppedDueToCollision = false;
                stopTimer = 0f;
                agent.isStopped = false;
            }
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            if (!isFollowing)
            {
                StartChase();
            }
            isFollowing = true;
        }
        else
        {
            if (isFollowing)
            {
                StopChase();
            }
            isFollowing = false;
        }

        if (isFollowing)
        {
            FollowPlayer();
        }
        else
        {
            Wander();
        }

        FixPositionAndRotation();
        HandleObstacles();
        UpdateHealthBarPosition();
    }

    void StartChase()
    {
        if (bgmSource != null && chaseBGM != null)
        {
            bgmSource.clip = chaseBGM;
            bgmSource.Play();
            bgmSource.loop = true; // BGM�����[�v����
        }
    }

    void StopChase()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    void FollowPlayer()
    {
        agent.SetDestination(player.position);
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            wanderTarget = RandomWanderTarget();
            timer = 0;
        }

        agent.SetDestination(wanderTarget);
    }

    Vector3 RandomWanderTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, -1);
        Vector3 target = navHit.position;
        target.y = fixedYPosition; // Y�|�W�V�������Œ�
        return target;
    }

    void FixPositionAndRotation()
    {
        // Y�|�W�V������2�ɌŒ�
        Vector3 fixedPosition = transform.position;
        fixedPosition.y = fixedYPosition;
        transform.position = fixedPosition;

        // X���̉�]��0�ɌŒ�
        Quaternion fixedRotation = transform.rotation;
        fixedRotation.eulerAngles = new Vector3(0, fixedRotation.eulerAngles.y, fixedRotation.eulerAngles.z);
        transform.rotation = fixedRotation;
    }

    void HandleObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, agent.radius + 0.5f, obstacleLayer))
        {
            // ��Q���ɋ߂Â��������ꍇ�̓G�[�W�F���g���~����
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            StopForSeconds(5); // 5�b�Ԓ�~����
        }

        if (collision.gameObject.CompareTag("Shell"))
        {
            TakeDamage(1); // ��e����1�_���[�W
            Destroy(collision.gameObject); // �e������
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            UpdateHealthBar(); // HP�o�[���X�V
        }
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void StopForSeconds(float seconds)
    {
        isStoppedDueToCollision = true;
        agent.isStopped = true;
        stopDuration = seconds;
    }

    void UpdateHealthBarPosition()
    {
        // NPC�̈ʒu�Ɋ�Â���HP�o�[�̈ʒu���X�V
        if (healthCanvas != null)
        {
            healthCanvas.transform.position = transform.position + Vector3.up * 2.5f; // NPC�̏�ɏ����I�t�Z�b�g
            healthCanvas.transform.rotation = Quaternion.LookRotation(healthCanvas.transform.position - Camera.main.transform.position); // �J�����������悤�ɉ�]
        }
    }
}
