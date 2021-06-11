using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem endParticles;
    [SerializeField] AudioClip deathExplosion;

    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint block in path)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
        // After reaching destination
        SelfDestruct();
    }

    void SelfDestruct()
    {
        var deathParticle = Instantiate(endParticles, transform.GetChild(0).position, transform.rotation);
        deathParticle.Play();
        AudioSource.PlayClipAtPoint(deathExplosion, Camera.main.transform.position, 0.75f);
        Destroy(gameObject);
    }
    
}
