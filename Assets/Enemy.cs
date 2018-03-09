using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public ParticleSystem particle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            print("Enemy!");
            particle.Play();
        }
    }
    */
}
