using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    bool checker;

	// Use this for initialization
	void Start () {
        
	}

    private void Update() {
        if (Input.anyKey && !checker) {
            checker = true;
            Invoke("LoadGameScene", 2f);
        }
    }


    void LoadGameScene () {
        SceneManager.LoadScene(1);
	}
}
