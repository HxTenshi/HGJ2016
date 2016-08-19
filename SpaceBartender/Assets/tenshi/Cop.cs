using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

    float m_Gauge;
    [SerializeField]
    GameObject m_Water;

    bool m_Max;

	// Use this for initialization
	void Start () {
        m_Gauge = 0;
        m_Water.transform.localScale = new Vector3(0.8f, 0, 0.8f);

    }
	
	// Update is called once per frame
	void Update () {
	    if(m_Max || m_Gauge>=3.0f){
            m_Max = true;
            m_Gauge -= Time.deltaTime;
            m_Gauge = Mathf.Max(m_Gauge, 0);
            WaterScale();
            if (m_Gauge <= 0.0f)
            {
                m_Max = false;
            }
        }
	}

    public void AddSyokuzai(Juice syokuzai)
    {
        m_Gauge += 1;

        var ren1 = m_Water.GetComponent<Renderer>();
        var ren2 = syokuzai.GetComponent<Renderer>();
        ren1.material.color *= (m_Gauge-1)/3.0f;
        ren1.material.color += ren2.material.color/ m_Gauge;
        WaterScale();
    }

    void WaterScale()
    {

        float y = m_Gauge / 3.0f;
        m_Water.transform.localScale = new Vector3(0.8f, y, 0.8f);
    }

}