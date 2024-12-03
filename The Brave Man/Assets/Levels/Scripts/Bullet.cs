using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху пулі
    public SpriteRenderer spriteRenderer; // Спрайт-рендер пулі
    public int attackBulletDamage = 30;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Отримуємо напрямок обличчя
        GameObject player = GameObject.FindGameObjectWithTag("Enemy2");
        if (player != null)
        {
            Enemy2 enemy2 = player.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                // Визначаємо напрямок руху пулі відповідно до напрямку обличчя героя
                Vector2 moveDirection = enemy2.faceRight ? Vector2.right : Vector2.left;
                // Встановлюємо швидкість руху пулі
                rb.velocity = moveDirection * moveSpeed;

                // Інвертуємо спрайт пулі по горизонталі в разі руху вліво
                if (!enemy2.faceRight)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }

        // Знищуємо пулю через певний час (якщо не влучить у ворога)
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Отримуємо компонент Enemy з об'єкта, з яким зіткнулась пуля
        TheBraveMan playerScript = other.GetComponent<TheBraveMan>();

        // Перевіряємо, чи отримали ми компонент Enemy
        if (playerScript != null)
        {
            // Викликаємо метод TakeDamage компонента Enemy
            playerScript.GetBulletDamage(attackBulletDamage);

            // Знищуємо пулю
            Destroy(gameObject);
        }
    }
}