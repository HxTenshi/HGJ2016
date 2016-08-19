using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public float time_max;
    float timer;
    RectTransform rect_transform;
	// Use this for initialization
	void Start () {
        timer = 0;
        rect_transform = GameObject.Find("bar").GetComponent<RectTransform>();
        Set();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Set();
        if(timer > time_max)
        {
            timer = time_max;
        }
    }

   void Set(){
        rect_transform.sizeDelta = new Vector2(230 * timer / time_max, 5);
    }
}
