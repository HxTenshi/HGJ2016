using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.Z)){
            SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);
        }
    }
}
