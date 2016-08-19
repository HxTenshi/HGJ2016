using UnityEngine;
using System.Collections;

public class Game_Control : MonoBehaviour {

    private int state;
    public int state_max;
	// Use this for initialization
	void Start () {
        state = 0;
	}

    void Update() {
        if (Input.GetButtonDown("Fire1")){
            if (++state > state_max) state = state_max;
        }
        if (Input.GetButtonDown("Fire2")){
                if (--state < 0) state = 0;
        }
    }

    public int Get () {
        return state;
	}
}
