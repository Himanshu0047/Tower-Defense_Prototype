using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)] [SerializeField] float secondsBetweenSpawn = 5f;
    [SerializeField] Enemy enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // forever
        {
            Instantiate(enemy, transform.position, enemy.transform.rotation, gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
