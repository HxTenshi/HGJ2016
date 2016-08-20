using UnityEngine;
using System.Collections;

public class PengLightControl : MonoBehaviour {

    private bool worning;
    private Game_Control game_control;
    private GameObject child;
    private GameObject child2;

    // Use this for initialization
    void Start () {
        game_control = GameObject.Find("GameControl").GetComponent<Game_Control>();
        child = gameObject.transform.Find("normal").gameObject;
        child2 = gameObject.transform.Find("worning").gameObject;
        worning = false;
    }

    // Update is called once per frame
    void Update () {
        int state = game_control.Get_state();
        if (state < 2) worning = true;
        else worning = false;
        if (worning)
        {
            child.SetActive(false);
            child2.SetActive(true);
            return;
        }
        child.SetActive(true);
        child2.SetActive(false);
    }
}
