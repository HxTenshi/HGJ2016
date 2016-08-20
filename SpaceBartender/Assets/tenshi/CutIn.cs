using UnityEngine;
using System.Collections;

public class CutIn : MonoBehaviour {

	float m_Time = 10.0f;
	float m_DT;

	// Use this for initialization
	void Start () {
		m_DT=0.0f;
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		m_DT+= Time.unscaledDeltaTime;

		//float t = (m_DT/m_Time);
		//t = Mathf.Pow(t,2.0f);

		transform.position += new Vector3(-0.5f,0,0) * Time.unscaledDeltaTime;

		if(m_DT>=m_Time){
			Time.timeScale = 1.0f;
			DestroyObject(gameObject);
		}
	}
}
