using UnityEngine;
using System.Collections;

public class Game_Control : MonoBehaviour {

    private int state;
    private int score;
    public int state_max;
	// Use this for initialization
	void Start () {
        state = 0;
        score = 0;
	}

    void Update() {
        if (score >= 600) state = 6;
        else if (score >= 500) state = 5;
        else if (score >= 400) state = 4;
        else if (score >= 300) state = 3;
        else if (score >= 200) state = 2;
        else if (score >= 100) state = 1;
    }

    public void Add_score(int score)
    {
        this.score += score;
    }

    public int Get_state() {
        return state;
	}
    public int Get_score(){
        return score;
    }
}
