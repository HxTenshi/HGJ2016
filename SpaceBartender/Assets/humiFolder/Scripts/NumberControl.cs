using UnityEngine;
using System.Collections;

public class NumberControl : MonoBehaviour {

    private Game_Control game_control;
    private Number child0;
    private Number child1;
    private Number child2;
    private Number child3;
    private Number child4;
    private Number child5;


    // Use this for initialization
    void Start()
    {
        game_control = GameObject.Find("GameControl").GetComponent<Game_Control>();
        child0 = gameObject.transform.Find("number0").GetComponent<Number>();
        child1 = gameObject.transform.Find("number1").GetComponent<Number>();
        child2 = gameObject.transform.Find("number2").GetComponent<Number>();
        child3 = gameObject.transform.Find("number3").GetComponent<Number>();
        child4 = gameObject.transform.Find("number4").GetComponent<Number>();
        child5 = gameObject.transform.Find("number5").GetComponent<Number>();
    }

    // Update is called once per frame
    void Update()
    {
        int number = game_control.Get_score();
        int score;
        child0.Set(0);
        for (int i = 0; i < 6; i++)
        {
            score = number % 10;
            number /= 10;
            if (score == 0 && number == 0)break;
            switch (i)
            {
                case 0:
                    child0.Set(score);
                    break;
                case 1:
                    child1.Set(score);
                    break;
                case 2:
                    child2.Set(score);
                    break;
                case 3:
                    child3.Set(score);
                    break;
                case 4:
                    child4.Set(score);
                    break;
                case 5:
                    child5.Set(score);
                    break;
            }
        }
    }
}
