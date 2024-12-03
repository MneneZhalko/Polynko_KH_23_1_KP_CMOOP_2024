using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ���� ���
    public SpriteRenderer spriteRenderer; // ������-������ ���
    public int attackBulletDamage = 30;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �������� �������� �������
        GameObject player = GameObject.FindGameObjectWithTag("Enemy2");
        if (player != null)
        {
            Enemy2 enemy2 = player.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                // ��������� �������� ���� ��� �������� �� �������� ������� �����
                Vector2 moveDirection = enemy2.faceRight ? Vector2.right : Vector2.left;
                // ������������ �������� ���� ���
                rb.velocity = moveDirection * moveSpeed;

                // ��������� ������ ��� �� ���������� � ��� ���� ����
                if (!enemy2.faceRight)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }

        // ������� ���� ����� ������ ��� (���� �� ������� � ������)
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �������� ��������� Enemy � ��'����, � ���� ��������� ����
        TheBraveMan playerScript = other.GetComponent<TheBraveMan>();

        // ����������, �� �������� �� ��������� Enemy
        if (playerScript != null)
        {
            // ��������� ����� TakeDamage ���������� Enemy
            playerScript.GetBulletDamage(attackBulletDamage);

            // ������� ����
            Destroy(gameObject);
        }
    }
}