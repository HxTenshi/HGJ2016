using UnityEngine;
using System.Collections;

public class LightSubControl : MonoBehaviour {

    private int old_state;
    private Game_Control game_control;
    private LightSub child1;
    private LightSub child2;
    private LightSub child3;
    private LightSub child4;
    private LightSub child5;
    private LightSub child6;

    // Use this for initialization
    void Start()
    {
        game_control = GameObject.Find("GameControl").GetComponent<Game_Control>();
        child1 = gameObject.transform.Find("Light1").GetComponent<LightSub>();
        child2 = gameObject.transform.Find("Light2").GetComponent<LightSub>();
        child3 = gameObject.transform.Find("Light3").GetComponent<LightSub>();
        child4 = gameObject.transform.Find("Light4").GetComponent<LightSub>();
        child5 = gameObject.transform.Find("Light5").GetComponent<LightSub>();
        child6 = gameObject.transform.Find("Light6").GetComponent<LightSub>();
        old_state = game_control.Get_state();
    }

    //Update is called once per frame
    void Update()
    {
        int state = game_control.Get_state();
        if (state == old_state) return;
        switch (old_state)
        {
            case 0:
                if (state > old_state) child1.Set(true);
                break;
            case 1:
                if (state > old_state) child2.Set(true);
                else child1.Set(false);
                break;
            case 2:
                if (state > old_state) child3.Set(true);
                else child2.Set(false);
                break;
            case 3:
                if (state > old_state) child4.Set(true);
                else child3.Set(false);
                break;
            case 4:
                if (state > old_state) child5.Set(true);
                else child4.Set(false);
                break;
            case 5:
                if (state > old_state) child6.Set(true);
                else child5.Set(false);
                break;
            case 6:
                if (state < old_state) child6.Set(false);
                break;
        }
        old_state = state;
    }
}
