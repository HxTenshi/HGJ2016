using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject backpre;
    public float interval;

    // Use this for initialization
    IEnumerator Start() {
        while (true) {
            Instantiate(backpre);

            yield return new WaitForSeconds(interval);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
