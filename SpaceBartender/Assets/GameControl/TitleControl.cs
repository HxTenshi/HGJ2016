using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
            SceneManager.LoadSceneAsync("humi", LoadSceneMode.Additive);
        }
    }
}
