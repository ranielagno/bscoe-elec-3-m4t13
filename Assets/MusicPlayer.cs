using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadGameScene", 2f);
	}
	
	
	void LoadGameScene () {
        SceneManager.LoadScene(1);
	}
}
