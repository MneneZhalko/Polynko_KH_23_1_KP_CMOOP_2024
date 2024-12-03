// Скрипт логіки першого рівня
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelManager : MonoBehaviour
{
    private int enemiesDestroyed = 0;

    [SerializeField] GameObject Finish;
    public GameObject EnemyPrefab;
    public GameObject Enemy2Prefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int spawned2 = 0;
    public int spawned4 = 0;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy2[] enemies2 = FindObjectsOfType<Enemy2>();

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
            if (spawned2 < 2)
            {
                Instantiate(EnemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
                spawned2++;
            }
        }

        if (enemiesDestroyed >= 4)
        {
            if (spawned4 < 1)
            {
                Instantiate(Enemy2Prefab, spawnPoint1.position, spawnPoint1.rotation);
                Instantiate(Enemy2Prefab, spawnPoint2.position, spawnPoint2.rotation);
                spawned4++;
            }
        }

        if (enemiesDestroyed >= 6)
        {
            GameObject finishObject = Finish;
            if (finishObject != null)
            {
                finishObject.SetActive(true);
            }
        }
    }
}