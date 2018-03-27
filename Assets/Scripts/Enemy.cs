using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] AudioSource sfx;

    int tridentScore = 10;
    int droidScore = 5;

    int tridentHits = 2;
    int droidHits = 1;

    int hits;
    int enemyDestroyScore;

    ScoreBoard scoreBoard;
    String enemyTag;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemyTag = gameObject.tag;

        if (enemyTag.Equals("Trident"))
        {
            hits = tridentHits;
            enemyDestroyScore = tridentScore;
        }
        else if (enemyTag.Equals("Droid"))
        {
            hits = droidHits;
            enemyDestroyScore = droidScore;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        hits -= 1;
        print("Enemy collision!");
        if (hits < 1)
        {
            EnemyDestroy();
            print("Enemy dead!");
            AddScore();
        }
    }

    private void AddScore()
    {
        scoreBoard.ScoreHit(enemyDestroyScore);
    }

    private void EnemyDestroy()
    {
        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        sfx.Play();
        Destroy(gameObject);
    }

}
