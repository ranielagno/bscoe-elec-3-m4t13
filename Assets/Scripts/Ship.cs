using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour {

    [SerializeField] ParticleSystem shipExplosion;
    [SerializeField] AudioSource explosionSfx;
    [SerializeField] float speed = 15f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        HVMovement();
        RotationalMovements();
    }

    private void RotationalMovements()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void HVMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Terrain")
        {
            print("Terrain!");
            explosionSfx.Play();
            shipExplosion.Play();
            StartCoroutine(restart());

        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
