using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        EnemyDestroy();
    }
	
	private void EnemyDestroy()
    {
        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }

}
