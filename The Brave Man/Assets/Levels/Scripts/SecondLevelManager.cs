// Скрипт логіки другого рівня
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelManager : MonoBehaviour
{
    public int enemiesDestroyed = 0;

    [SerializeField] GameObject Finish;
    public GameObject EnemyPrefab;
    public GameObject Enemy2Prefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int spawned1 = 0;
    public int spawned2 = 0;
    public int spawned1sec = 0;
    public int spawned1thr = 0;

    private Enemy[] enemies;
    private Enemy2[] enemies2;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        int savedHumans = HumanCircle.GetTotalSaved();

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

        if (enemiesDestroyed >= 2 && savedHumans == 1)
        {
            if (spawned1 < 1)
            {
                Instantiate(Enemy2Prefab, spawnPoint2.position, spawnPoint2.rotation);
                spawned1++;
            }
        }

        if (enemiesDestroyed >= 3)
        {
            if (spawned2 < 1)
            {
                Instantiate(EnemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
                Instantiate(EnemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
                spawned2++;
            }
        }

        if (savedHumans == 2)
        {
            if (spawned1sec < 1)
            {
                Instantiate(EnemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
                spawned1sec++;
            }
        }

        if (savedHumans == 3 && enemiesDestroyed >= 6)
        {
            if(spawned1thr < 1)
            {
                Instantiate(Enemy2Prefab, spawnPoint2.position, spawnPoint2.rotation);
                spawned1thr++;
            }
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

        spawned1 = 0;
        spawned2 = 0;
        spawned1sec = 0;
    }
}
