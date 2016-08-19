using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shutter : MonoBehaviour {

    private RectTransform hoge;

    private Image image;
    private float time;
    public float fadetime;

    public float y;

	// Use this for initialization
	void Start () {

        //time = fadetime;
        time = 0;//初期化
        image = GetComponent<Image>();//imageコンポネントを取得

        hoge = GameObject.Find("Shutter").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (y >= 0) {

            y -= 1080 / 90;
        }


        if(y <= 0){
            time += Time.deltaTime;//時間更新.今度は増えていく
            float a = time / fadetime;
            var color = image.color;
            color.a = a;
            image.color = color;
        }

        hoge.localPosition = new Vector3(0, y, 0);
	}
}
