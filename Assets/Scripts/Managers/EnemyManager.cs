using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Globalization;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private Transform player;
    [SerializeField] private int maxHp;
    [SerializeField] private float followDistance;
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderTimer;
    [SerializeField] private float fixedYPosition;
    [SerializeField] private int damageAmount; // プレイヤーに与えるダメージ量
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private AudioSource bgmSource; // BGMを再生するためのAudioSource
    [SerializeField] private AudioClip chaseBGM; // 追尾時に再生するBGM
    [SerializeField] private Slider healthSlider; // HPバーのSlider
    [SerializeField] private Canvas healthCanvas; // HPバーのCanvas


    private int currentHealth;

   
    private NavMeshAgent agent;
    private bool isFollowing = false;
    private float timer;
    private Vector3 wanderTarget;
    private bool isStoppedDueToCollision = false;
    private float stopTimer = 0f;
    private float stopDuration = 5f;

    public Text chaseText;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        wanderTarget = RandomWanderTarget();
        currentHealth = maxHp;
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
                StartChaseBGM();
                ChaseText(true);
            }
            isFollowing = true;
        }
        else
        {
            if (isFollowing)
            {
                StopChaseBGM();
                ChaseText(false);
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



    void StartChaseBGM()
    {
        if (bgmSource != null && chaseBGM != null)
        {
            bgmSource.clip = chaseBGM;
            bgmSource.Play();
            bgmSource.loop = true; // BGMをループする
        }
    }

    void ChaseText(bool isActive)
    {
        if (chaseText != null)
            {
            if (isActive)
            {
                chaseText.text = "追いかけられている！";
                chaseText.gameObject.SetActive(true);
            }
            else
            {
                chaseText.gameObject.SetActive(false);
            }
        }
    }

    void StopChaseBGM()
    {
        if(bgmSource != null)
        {
            bgmSource.Stop();
        }
    }

    
    
    /// <summary>
    /// プレイヤーの位置を取得
    /// </summary>
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
        target.y = fixedYPosition; // Yポジションを固定
        return target;
    }

    void FixPositionAndRotation()
    {
        Vector3 fixedPosition = transform.position;
        fixedPosition.y = fixedYPosition;
        transform.position = fixedPosition;

        // X軸の回転を0に固定
        Quaternion fixedRotation = transform.rotation;
        fixedRotation.eulerAngles = new Vector3(0, fixedRotation.eulerAngles.y, fixedRotation.eulerAngles.z);
        transform.rotation = fixedRotation;
    }

    void HandleObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, agent.radius + 0.5f, obstacleLayer))
        {
            // 障害物に近づきすぎた場合はエージェントを停止する
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

            StopForSeconds(5); // 5秒間停止する
        }

        if (collision.gameObject.CompareTag("Shell"))
        {
            TakeDamage(1); // 被弾時に1ダメージ
            Destroy(collision.gameObject); // 弾を消す
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            chaseText.gameObject.SetActive(false);
        }
        else
        {
            UpdateHealthBar(); // HPバーを更新
        }
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHp;
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
        // NPCの位置に基づいてHPバーの位置を更新
        if (healthCanvas != null)
        {
            healthCanvas.transform.position = transform.position + Vector3.up * 2.5f; // NPCの上に少しオフセット
            healthCanvas.transform.rotation = Quaternion.LookRotation(healthCanvas.transform.position - Camera.main.transform.position); // カメラを向くように回転
        }
    }
}
