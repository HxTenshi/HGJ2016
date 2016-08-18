using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

    float m_Gauge;
    [SerializeField]
    GameObject m_Water;

	// Use this for initialization
	void Start () {
        m_Gauge = 0;
        m_Water.transform.localScale = new Vector3(1, 0, 1);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddSyokuzai(Juice syokuzai)
    {
        m_Gauge += 1;
        float y = m_Gauge / 3.0f;
        m_Water.transform.localScale = new Vector3(1, y, 1);
    }

}