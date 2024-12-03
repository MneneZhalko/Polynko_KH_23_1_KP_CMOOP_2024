// Скрипт логіки злодію далекого бою
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform bulletSpawnPoint;
    public bool counted = false;

    public GameObject hp;
    private float timeBtwAttack;
    public float starttimeBtwAttack = 3f;
    bool attacking = false;
    public float lastHitTime = 0f;
    public float deathtimer = 0f;
    public bool death = false;

    public int maxHealth = 100;
    int currentHealth;
    public static bool enemyKilledAchievement = false;
    private float stopTime;
    public float startStopTime;

    public float detectionRadius = 5f;
    float attackTimer = 0f;

    private Transform player;
    private Animator animator;

    private TheBraveMan theBraveMan;

    public bool faceRight = true;

    public float attackplaying = 0f;

    public AudioClip attackSound;
    private AudioSource audioSource;

    void Start()
    {
        enemyKilledAchievement = PlayerPrefs.GetInt("enemyKilledAchievement", 0) == 1;
        currentHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        theBraveMan = FindObjectOfType<TheBraveMan>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (attacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 1f)
            {
                attacking = false;
                attackTimer = 0f;
            }
        }

        if (player != null && !death)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < detectionRadius)
            {
                Reflect();
                if (!attacking)
                {
                    if (timeBtwAttack <= 0)
                    {
                        animator.SetTrigger("Attacking");
                        OnEnemyAttack();
                        attackplaying = 0f;
                    }
                    else
                    {
                        timeBtwAttack -= Time.deltaTime;
                    }
                }
                else
                {
                    if (attackplaying >= 1f)
                    {
                        animator.SetTrigger("Idle");
                    }
                }
            }
        }

        if (death)
        {
            deathtimer += Time.deltaTime;

            if (deathtimer >= 2.0f)
            {
                Instantiate(hp, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void Reflect()
    {
        if (!death)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            if ((directionToPlayer.x > 0 && !faceRight) || (directionToPlayer.x < 0 && faceRight))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                faceRight = !faceRight;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!death)
        {
            stopTime = startStopTime;
            currentHealth -= damage;
            animator.SetTrigger("Get Damage");
            Debug.Log("HP Enemy: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void OnEnemyAttack()
    {
        if (!death)
        {
            audioSource.PlayOneShot(attackSound);
            attacking = true;
            Shoot();
            timeBtwAttack = starttimeBtwAttack;
        }
    }

    void Shoot()
    {
        if (bulletSpawnPoint != null && BulletPrefab != null)
        {
            GameObject newBullet = Instantiate(BulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Destroy(newBullet, 3f);
        }
    }

    void Die()
    {
        if (!enemyKilledAchievement)
        {
            enemyKilledAchievement = true;
            PlayerPrefs.SetInt("enemyKilledAchievement", 1);
            PlayerPrefs.Save();
        }

        animator.SetTrigger("Death");
        death = true;
    }
}