using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class vault : MonoBehaviour {

    int font_num;
    public int font_max;
    string score;
    Text text;
    private Game_Control game_control;


    // Use this for initialization
    void Start () {
        game_control = GameObject.Find("GameControl").GetComponent<Game_Control>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        int number;
        font_num = 0;        
        number = game_control.Get_score();
        score = "" + number;
        do {
            number /= 10;
            font_num++;
        } while (number != 0);
        text.text = score;
    }
}
