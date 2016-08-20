using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float time_max;
    float timer;
    bool flag;
    RectTransform rect_transform;
	// Use this for initialization
	void Start () {
        flag = false;
        timer = 0;
        rect_transform = GameObject.Find("bar").GetComponent<RectTransform>();
        Set();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Set();
        if(timer > time_max){
            if(!flag)SceneManager.LoadSceneAsync("Result", LoadSceneMode.Additive);
            timer = time_max;
            flag = true;
        }
    }

   void Set(){
        rect_transform.sizeDelta = new Vector2(597 * timer / time_max, 20);
    }
}
