using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result : MonoBehaviour {

    private Image image;
    private float time;
    public float fadetime;

    void Start() {
        //time = fadetime;
        time = 0;//初期化
        image = GetComponent<Image>();//imageコンポネントを取得
    }

    void Update() {
        time += Time.deltaTime;//時間更新.今度は増えていく
        float a = time / fadetime;
        var color = image.color;
        color.a = a;
        image.color = color;
    }
    
}
