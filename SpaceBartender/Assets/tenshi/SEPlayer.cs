using UnityEngine;
using System.Collections;

public class SEPlayer : MonoBehaviour {

	AudioSource m_AudioSource = null;
	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_AudioSource==null)return;

		if(!m_AudioSource.isPlaying){
			DestroyObject(gameObject);
		}
	}
}
