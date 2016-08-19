using UnityEngine;
using System.Collections;

public class Light_Control : MonoBehaviour {

    private int old_state;
    private Game_Control game_control;
    private Light child1;
    private Light child2;
    private Light child3;
    private Light child4;
    private Light child5;
    private Light child6;

    // Use this for initialization
    void Start () {
        game_control = GameObject.Find("GameControl").GetComponent<Game_Control>();
        child1 = gameObject.transform.Find("Light1").GetComponent<Light>();
        child2 = gameObject.transform.Find("Light2").GetComponent<Light>();
        child3 = gameObject.transform.Find("Light3").GetComponent<Light>();
        child4 = gameObject.transform.Find("Light4").GetComponent<Light>();
        child5 = gameObject.transform.Find("Light5").GetComponent<Light>();
        child6 = gameObject.transform.Find("Light6").GetComponent<Light>();
        old_state = game_control.Get();
    }

    //Update is called once per frame
    void Update()
    {
        int state = game_control.Get();
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
