using UnityEngine;
using System.Collections;

public class LightMain : MonoBehaviour {

    private bool draw_type;
    private GameObject child;


    // Use this for initialization
    void Start()
    {
        child = gameObject.transform.Find("main").gameObject;
        draw_type = false;
        Change();
    }

    public void Set(bool flag)
    {
        draw_type = flag;
        Change();
    }


    void Change()
    {
        if (draw_type)
        {
            child.SetActive(true);
            return;
        }
        child.SetActive(false);
    }
}
