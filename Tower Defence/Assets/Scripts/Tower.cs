using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] ParticleSystem bullets;
    [SerializeField] float attackRange = 30;

    Transform target;
    public Waypoint baseWaypoint;


    void Update()
    {
        SetTarget();
        if (target)
        {
            objectToMove.LookAt(target);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    void SetTarget()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if(sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(Enemy test in sceneEnemies)
        {
            float gap1 = Vector3.Distance(transform.position, closestEnemy.position);
            float gap2 = Vector3.Distance(transform.position, test.transform.position);
            if(gap2 < gap1)
            {
                closestEnemy = test.transform;
            }
        }

        target = closestEnemy.GetChild(0).transform;
    }

    void FireAtEnemy()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;

    }
}
