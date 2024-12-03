using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float moveSpeed = 7f;
    public SpriteRenderer spriteRenderer;
    public int attackDartDamage = 100;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            TheBraveMan hero = player.GetComponent<TheBraveMan>();
            if (hero != null)
            {
                Vector2 moveDirection = hero.faceRight ? Vector2.right : Vector2.left;
                rb.velocity = moveDirection * moveSpeed;

                if (!hero.faceRight)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemyScript = other.GetComponent<Enemy>();
        Enemy2 enemy2Script = other.GetComponent<Enemy2>();

        if (enemyScript != null && other.CompareTag("Enemy"))
        {
            enemyScript.TakeDamage(attackDartDamage);

            Destroy(gameObject);
        }
        if (enemy2Script != null && other.CompareTag("Enemy2"))
        {
            enemy2Script.TakeDamage(attackDartDamage);

            Destroy(gameObject);
        }
    }
}