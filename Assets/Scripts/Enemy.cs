using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] AudioSource sfx;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        print("Enemy dead!");
        EnemyDestroy();
    }
	
	private void EnemyDestroy()
    {
        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        sfx.Play();
        Destroy(gameObject);
    }

}
