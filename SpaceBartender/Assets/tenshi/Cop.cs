using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

    float m_Gauge;
    [SerializeField]
    GameObject m_Water;

    bool m_Max;
	[SerializeField]
	int m_CopID;

	[SerializeField]
	GameObject m_WaterInSE;

	int m_Filter;

	[SerializeField]
	CustomerControllScript m_CustomerControllScript;

	// Use this for initialization
	void Start () {
        m_Gauge = 0;
        m_Water.transform.localScale = new Vector3(0.8f, 0, 0.8f);
		m_Filter=0;

    }
	
	// Update is called once per frame
	void Update () {
	    if(m_Max || m_Gauge>=3.0f){
			if(!m_Max){
				if(m_CustomerControllScript!=null)m_CustomerControllScript.Drinling(m_CopID,m_Filter);
				m_Filter=0;
			}
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
		m_Filter |= syokuzai.SyokuzaiType;
        var ren1 = m_Water.GetComponent<Renderer>();
        var ren2 = syokuzai.GetComponent<Renderer>();
        ren1.material.color *= (m_Gauge-1)/3.0f;
        ren1.material.color += ren2.material.color/ m_Gauge;
        WaterScale();

		if(m_CustomerControllScript!=null)m_CustomerControllScript.Drip(m_CopID);
		Instantiate(m_WaterInSE);
    }

    void WaterScale()
    {

        float y = m_Gauge / 3.0f;
        m_Water.transform.localScale = new Vector3(0.8f, y, 0.8f);
    }

}