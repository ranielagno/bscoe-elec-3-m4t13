using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainCollisionHandler : MonoBehaviour {

    [SerializeField] ParticleSystem shipExplosion;
    [SerializeField] AudioSource explosionSfx;
    
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.collider.tag == "Terrain")
        {
            explosionSfx.Play();
            shipExplosion.Play();
            StartCoroutine(restart());

        }
        */
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
