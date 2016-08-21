using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scrool : MonoBehaviour {

    private RectTransform hoge;

    public float y = 40;
    private float offset = 0;

    void Start() {

        hoge = GameObject.Find("BackScrool").GetComponent<RectTransform>();
    }

	// Update is called once per frame
	void Update () {

        if (y <= 2160 - 1080+550) {

            y += 2160 / 600;
        }

        hoge.localPosition = new Vector3(0, y, 0);
	}
}
