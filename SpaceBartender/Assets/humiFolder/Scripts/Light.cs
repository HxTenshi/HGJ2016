using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {

    private bool draw_type;
    private GameObject child;
    private GameObject child2;


    // Use this for initialization
    void Start () {
        child = gameObject.transform.Find("on").gameObject;
        child2 = gameObject.transform.Find("off").gameObject;
        draw_type = false;
        Change();
    }

    public void Set(bool flag){
        draw_type = flag;
        Change();
    }


    void Change(){
        if (draw_type)
        {
            child.SetActive(true);
            child2.SetActive(false);
            return;
        }
        child.SetActive(false);
        child2.SetActive(true);
    }
}
