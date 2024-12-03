// Скрипт логіки третього рівня
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevelManager : MonoBehaviour
{
    public int enemiesDestroyed = 0;

    [SerializeField] GameObject Finish;
    public GameObject EnemyPrefab;
    public GameObject Enemy2Prefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public int spawned2 = 0;
    public int spawned3 = 0;
    public int spawned2sec = 0;

    private Enemy[] enemies;
    private Enemy2[] enemies2;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();
        enemies2 = FindObjectsOfType<Enemy2>();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.death && !enemy.counted)
            {
                enemy.counted = true;
                enemiesDestroyed++;
            }
        }

        foreach (Enemy2 enemy in enemies2)
        {
            if (enemy.death && !enemy.counted)
            {
                enemy.counted = true;
                enemiesDestroyed++;
            }
        }

        if (enemiesDestroyed >= 2)
        {
            if (spawned3 < 1)
            {
                Instantiate(Enemy2Prefab, spawnPoint1.position, spawnPoint1.rotation);
                Instantiate(EnemyPrefab, spawnPoint1.position, spawnPoint2.rotation);
                Instantiate(EnemyPrefab, spawnPoint3.position, spawnPoint3.rotation);
                spawned3++;
            }
        }

        if (enemiesDestroyed >= 4)
        {
            if (spawned2 < 1)
            {
                Instantiate(Enemy2Prefab, spawnPoint2.position, spawnPoint2.rotation);
                spawned2++;
            }
        }

        if (enemiesDestroyed >= 6)
        {
            if (spawned2sec < 1)
            {
                Instantiate(EnemyPrefab, spawnPoint3.position, spawnPoint3.rotation);
                Instantiate(EnemyPrefab, spawnPoint3.position, spawnPoint3.rotation);
                spawned2sec++;
            }
        }

        if (enemiesDestroyed >= 8)
        {
            GameObject finishObject = Finish;
            if (finishObject != null)
            {
                finishObject.SetActive(true);
            }
        }
    }

    public void SetAllNull()
    {
        enemiesDestroyed = 0;
        HumanCircle.ResetSavedHumans();

        enemies = FindObjectsOfType<Enemy>();
        enemies2 = FindObjectsOfType<Enemy2>();

        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        foreach (Enemy2 enemy in enemies2)
        {
            Destroy(enemy.gameObject);
        }

        spawned3 = 0;
        spawned2 = 0;
        spawned2sec = 0;
    }
}