// Скрипт логіки злодію ближнього бою

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hp;
    private float timeBtwAttack;
    public float starttimeBtwAttack;
    bool attacking = false;
    public float lastHitTime = 0f;
    public bool death = false;
    public bool counted = false;

    public bool attackSoundplayed = false;
    public int maxHealth = 100;
    int currentHealth;
    public static bool enemyKilledAchievement = false;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalspeed;
    public float deathtimer = 0f;

    public float detectionRadius = 5f;
    public float speed = 3f;
    float attackTimer = 0f;

    private Transform player;
    private Animator animator;

    private TheBraveMan theBraveMan;

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

    private bool isMoving = false;

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

            if (distanceToPlayer < detectionRadius && !attacking)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime);

                isMoving = true;
                animator.SetBool("IsMoving", isMoving);

                moveVector = direction;
            }
            else
            {
                isMoving = false;
                animator.SetBool("IsMoving", isMoving);
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

        Reflect();

        if (stopTime <= 0)
        {
            speed = normalspeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }

    public bool faceRight = true;
    private Vector2 moveVector;

    void Reflect()
    {
        if (player != null && !death)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < detectionRadius)
            {
                Vector3 directionToPlayer = player.position - transform.position;
                if ((directionToPlayer.x > 0 && !faceRight) || (directionToPlayer.x < 0 && faceRight))
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    faceRight = !faceRight;
                }
            }
        }
    }

    public void TakeDamage(int damage)
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

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                if (!attackSoundplayed)
                {
                    audioSource.PlayOneShot(attackSound);
                    attackSoundplayed = true;
                }
                animator.SetTrigger("Attacking");
            }
            else
            {
                attackSoundplayed = false;
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        if (!death)
        {
            timeBtwAttack = starttimeBtwAttack;
            attacking = true;
            theBraveMan.health -= damage;
            Debug.Log("HP The Brave Man: " + theBraveMan.health);

            if (theBraveMan.health > 0)
            {
                theBraveMan.PlayGetDamageAnimation();
            }
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
