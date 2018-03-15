using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] AudioSource sfx;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Enemy dead!");
        EnemyDestroy();
        AddScore();
    }

    private void AddScore()
    {
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void EnemyDestroy()
    {
        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        sfx.Play();
        Destroy(gameObject);
    }

}
