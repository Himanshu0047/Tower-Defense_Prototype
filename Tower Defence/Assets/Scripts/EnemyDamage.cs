using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem enemyHitParticles;
    [SerializeField] ParticleSystem enemyDeathParticles;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip deathExplosion;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        enemyHitParticles.Play();
        GetComponent<AudioSource>().PlayOneShot(hit);
    }

    void ProcessHit()
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        FindObjectOfType<PlayerHealth>().UpdateScore();
        var deathParticle = Instantiate(enemyDeathParticles, transform.GetChild(0).position, transform.rotation);
        deathParticle.Play();
        AudioSource.PlayClipAtPoint(deathExplosion, Camera.main.transform.position, 0.75f);
        Destroy(gameObject);
    }
}
