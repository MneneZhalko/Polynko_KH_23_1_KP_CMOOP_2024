using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TheBraveMan : MonoBehaviour
{
    public GameObject HumanCircle;
    public Bullet bulletScript;
    public GameObject winPanel;
    public GameObject losePanel;

    public Text dartsCountText;
    public Text healthText;

    public GameObject dartPrefab;
    public GameObject humanPrefab;
    public Transform dartSpawnPoint;
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 6f;
    public float health = 100;
    public float maxhealth = 100;
    public float minhealth = 0;
    public float jumpForce;
    public int jumpcount;
    public float jumptimer;
    public bool helping = false;
    public int humanpicked = 0;

    public float lvlendedtimer = 0f;
    public bool lvlended = false;

    public Transform attack1point;
    public Transform attack2point;
    public Transform attack3point;
    public Transform attack4point;
    public float attack1Range = 0.5f;
    public float attack2Range = 0.5f;
    public float attack3Range = 0.5f;
    public float attack4Range = 5f;
    public LayerMask enemyLayers;

    public Animator animator;

    public int attack1Damage = 20;
    public int attack2Damage = 40;
    public int attack3Damage = 60;
    public int attack4Damage = 150;

    public float attackRate = 3f;
    public bool attackBlock = false;
    float nextAttack1Time = 0f;
    float nextAttack2Time = 0f;
    public bool attack1Playing = false;
    public bool attack2Playing = false;
    public bool attack3Playing = false;
    public bool attack4Playing = false;
    public bool notdead = true;
    public float attack1PlayingTimer = 0f;
    public float attack2PlayingTimer = 0f;
    public bool playedLoseSound = false;
    int amount = 0;
    public float timetodeath = 0f;
    public bool walksoundplayer = false;
    public bool walksoundplayerGround = false;

    float comboTimer = 0f;
    bool combo1part1 = false;
    bool combo1part2 = false;
    bool combo2part = false;
    float combo2Timer = 0f;
    int dartscount = 3;
    public float humantimer = 0f;

    private bool isCollidingWithHuman = false;
    private GameObject humanObject;

    public AudioClip attackSound;
    public AudioClip attack4Sound;
    public AudioClip dartSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    public AudioClip walkSound;
    private AudioSource audioSource;
    private AudioSource backgroundMusicSource;
    private AudioSource walkAudioSource;

    public bool humansSavedCompletedAchievement = false;


    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("DartSpawnPoint"))
            {
                dartSpawnPoint = child;
                break;
            }
        }

        rb = GetComponent<Rigidbody2D>();
        bulletScript = GameObject.FindObjectOfType<Bullet>();
        audioSource = GetComponent<AudioSource>();
        walkAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Оновлення тексту в реальному часі
        dartsCountText.text = dartscount.ToString();
        healthText.text = Mathf.Clamp(health, 0, maxhealth).ToString();

        humansSavedCompletedAchievement = PlayerPrefs.GetInt("humansSavedCompletedAchievement", 0) == 1;

        if (helping)
        {
            humantimer += Time.deltaTime;
        }
        if (notdead && !lvlended)
        {
            Walk();
            Jump();

            ComboTimer();
            if (attack1Playing)
            {
                attack1PlayingTimer += Time.deltaTime;

                if (attack1PlayingTimer > 0.5f)
                {
                    attack1Playing = false;
                    attack1PlayingTimer = 0f;
                }
            }
            else if (Time.time >= nextAttack1Time)
            {
                Reflect();
                if (Input.GetMouseButtonDown(0) && !attackBlock && !helping)
                {
                    Attack1();
                    attack1Playing = true;
                    nextAttack1Time = Time.time + 2f / attackRate;
                }
            }
            if (Time.time >= nextAttack2Time)
            {
                if (Input.GetMouseButtonDown(1) && !attackBlock && !helping)
                {
                    Attack2();
                    attack2Playing = true;
                    nextAttack2Time = Time.time + 3f / attackRate;
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && dartscount >= 1 && !helping)
            {
                ShootDart();
                dartscount -= 1;
                combo2part = true;
            }

            if (maxhealth < health)
            {
                health = maxhealth;
            }
            if (minhealth > health)
            {
                health = minhealth;
            }
        }
        else
        {
            timetodeath += Time.deltaTime;
            if (timetodeath > 2.5f && !lvlended)
            {
                losePanel.SetActive(true);
                StopBackgroundMusic();
                if (!playedLoseSound)
                {
                    PlaySound(loseSound);
                    Time.timeScale = 0;
                    playedLoseSound = true;
                }
            }
        }

        if (isCollidingWithHuman && Input.GetKeyDown(KeyCode.E))
        {
            if (humanpicked < 1)
            {
                helping = true;
                Destroy(humanObject);
                GameObject humanCircleObject = HumanCircle;
                if (humanCircleObject != null)
                {
                    humanCircleObject.SetActive(true);
                }
                humanpicked++;
            }
        }
        if (humantimer >= 1f && Input.GetKeyDown(KeyCode.E) && helping)
        {
            humantimer = 0f;
            helping = false;
            humanpicked = 0;
            GameObject human = Instantiate(humanPrefab, dartSpawnPoint.position, Quaternion.identity);
        }

        Die();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y);

        if (moveVector.x != 0)
        {
            if (!walksoundplayer && walksoundplayerGround)
            {
                PlayWalkSound(walkSound);
                walksoundplayer = true;
            }
            if (!helping)
            {
                speed = 6f;
                animator.SetTrigger("Run");
            }
            else
            {
                speed = 4f;
                animator.SetTrigger("Move");
            }
        }
        else if (moveVector.x == 0)
        {
            walkAudioSource.Stop();
            walksoundplayer = false;
            if (!helping)
            {
                animator.SetTrigger("TheBraveManIdle");
            }
            if (helping)
            {
                animator.SetTrigger("IdlewithHuman");
            }
        }
        if (!walksoundplayerGround)
        {
            walkAudioSource.Stop();
        }
    }

    public bool faceRight = true;
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Attack1()
    {
        PlaySound(attackSound);

        if (combo1part1 && combo1part2)
        {
            attack3Playing = true;
            animator.SetTrigger("Attack3");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack3point.position, attack3Range, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                Enemy2 enemy2Script = enemy.GetComponent<Enemy2>();

                if (enemyScript != null && enemyScript.lastHitTime + 0.05f < Time.time)
                {
                    enemyScript.TakeDamage(attack3Damage);
                    enemyScript.lastHitTime = Time.time;
                }
                if (enemy2Script != null && enemy2Script.lastHitTime + 0.05f < Time.time)
                {
                    enemy2Script.TakeDamage(attack3Damage);
                    enemy2Script.lastHitTime = Time.time;
                }
            }
        }
        else
        {
            attack1Playing = true;
            animator.SetTrigger("Attack1");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1point.position, attack1Range, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                Enemy2 enemy2Script = enemy.GetComponent<Enemy2>();

                if (enemyScript != null && enemyScript.lastHitTime + 0.05f < Time.time)
                {
                    enemyScript.TakeDamage(attack1Damage);
                    enemyScript.lastHitTime = Time.time;
                }
                if (enemy2Script != null && enemy2Script.lastHitTime + 0.05f < Time.time)
                {
                    enemy2Script.TakeDamage(attack1Damage);
                    enemy2Script.lastHitTime = Time.time;
                }
            }

            combo1part1 = true;
        }
    }

    void Attack2()
    {
        if (combo2part && humansSavedCompletedAchievement)
        {
            PlaySound(attack4Sound);
            attack4Playing = true;
            animator.SetTrigger("Attack4");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack4point.position, attack4Range, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                Enemy2 enemy2Script = enemy.GetComponent<Enemy2>();

                if (enemyScript != null && enemyScript.lastHitTime + 0.05f < Time.time)
                {
                    enemyScript.TakeDamage(attack4Damage);
                    enemyScript.lastHitTime = Time.time;
                }
                if (enemy2Script != null && enemy2Script.lastHitTime + 0.05f < Time.time)
                {
                    enemy2Script.TakeDamage(attack4Damage);
                    enemy2Script.lastHitTime = Time.time;
                }
            }
        }
        else
        {
            PlaySound(attackSound);
            attack2Playing = true;
            animator.SetTrigger("Attack2");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack2point.position, attack2Range, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                Enemy2 enemy2Script = enemy.GetComponent<Enemy2>();

                if (enemyScript != null && enemyScript.lastHitTime + 0.05f < Time.time)
                {
                    enemyScript.TakeDamage(attack2Damage);
                    enemyScript.lastHitTime = Time.time;
                }
                if (enemy2Script != null && enemy2Script.lastHitTime + 0.05f < Time.time)
                {
                    enemy2Script.TakeDamage(attack2Damage);
                    enemy2Script.lastHitTime = Time.time;
                }
            }

            if (combo1part1)
            {
                combo1part2 = true;
                nextAttack1Time = 0f;
            }
        }
    }

    public void GetBulletDamage(int damage)
    {
        if (notdead)
        {
            health -= damage;
            Debug.Log("HP The Brave Man: " + health);
            PlayGetDamageAnimation();
            PlaySound(damageSound);
        }
    }

    void ShootDart()
    {
        if (dartSpawnPoint != null && dartPrefab != null)
        {
            PlaySound(dartSound);
            animator.SetTrigger("Dart");
            GameObject newDart = Instantiate(dartPrefab, dartSpawnPoint.position, Quaternion.identity);
            Destroy(newDart, 3f);
        }
    }

    public void PlayGetDamageAnimation()
    {
        animator.SetTrigger("GetDamage");
    }

    void Die()
    {
        if (health <= 0 && notdead)
        {
            notdead = false;
            animator.SetTrigger("Death");
        }
    }

    void Jump()
    {
        if (jumpcount < 2 && Input.GetKeyDown(KeyCode.Space) && !helping)
        {
            PlaySound(jumpSound);
            attackBlock = true;
            animator.SetTrigger("Jump");

            rb.AddForce(Vector2.up * jumpForce);
            walksoundplayerGround = false;

            jumpcount++;
        }   

        if (jumpcount >= 2)
        {
            jumptimer += Time.deltaTime;
            if (jumptimer >= 1.3f)
            {
                jumpcount = 0;
                jumptimer = 0f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attack1point == null)
            return;

        Gizmos.DrawWireSphere(attack1point.position, attack1Range);

        if (attack2point == null)
            return;

        Gizmos.DrawWireSphere(attack2point.position, attack2Range);

        if (attack3point == null)
            return;

        Gizmos.DrawWireSphere(attack3point.position, attack3Range);
    }

    public void Heal()
    {
        health += amount;
    }

    void OnCollisionEnter2D(Collision2D Stolknovenie)
    {
        if (Stolknovenie.gameObject.tag == "HP")
        {
            Destroy(Stolknovenie.gameObject);
            amount = 10;
            Heal();
            Debug.Log("HP The Brave Man: " + health);
        }
        if (Stolknovenie.gameObject.tag == "Ground")
        {
            attackBlock = false;
            animator.SetTrigger("Idle");
            jumpcount = 0;
            walksoundplayerGround = true;
        }
        if (Stolknovenie.gameObject.tag == "Finish")
        {
            lvlended = true;
            animator.SetTrigger("End");
            StopBackgroundMusic();
            PlaySound(winSound);
            winPanel.SetActive(true);
        }
        if (Stolknovenie.gameObject.tag == "Human")
        {
            isCollidingWithHuman = true;
            humanObject = Stolknovenie.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D Stolknovenie)
    {
        if (Stolknovenie.gameObject.tag == "Human")
        {
            isCollidingWithHuman = false;
            humanObject = null;
        }
    }

    void ComboTimer()
    {
        if (combo1part1)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer >= 3.0f)
            {
                combo1part1 = false;
                combo1part2 = false;
                comboTimer = 0.0f;
            }
        }
        if (combo2part)
        {
            combo2Timer += Time.deltaTime;
            if (combo2Timer >= 1.0f)
            {
                combo2part = false;
                combo2Timer = 0.0f;
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void StopBackgroundMusic()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }
    }

    void PlayWalkSound(AudioClip clip)
    {
        walkAudioSource.PlayOneShot(clip);
    }
}