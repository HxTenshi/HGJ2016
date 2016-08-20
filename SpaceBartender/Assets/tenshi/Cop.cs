using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Cop : MonoBehaviour {

    float m_Gauge;
    [SerializeField]
    GameObject m_Water;

    //Game_Control gamecontrol;

    bool m_Max;
	[SerializeField]
	int m_CopID;

	[SerializeField]
	GameObject m_WaterInSE;


	[SerializeField]
	List<GameObject> m_CutIn;

	string[] m_SyokuzaiNames = new string[3];

	int m_Filter;

	[SerializeField]
	CustomerControllScript m_CustomerControllScript;

	// Use this for initialization
	void Start () {
        m_Gauge = 0;
        m_Water.transform.localScale = new Vector3(0.0f, 0, 0.0f);
		m_Filter=0;
        //gamecontrol = GameObject.Find("GameControl").GetComponent<Game_Control>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(m_Max || m_Gauge>=3.0f){
			if(!m_Max){

				CutInCheck();

				if(m_CustomerControllScript!=null)m_CustomerControllScript.Drinling(m_CopID,m_Filter);
				m_Filter=0;
			}
            m_Max = true;
            m_Gauge -= Time.deltaTime;
            m_Gauge = Mathf.Max(m_Gauge, 0);
            WaterScale();
            if (m_Gauge <= 0.0f)
            {
                //if (m_Max) gamecontrol.Add_score(50);
                m_Max = false;
            }
        }
	}

    public void AddSyokuzai(Juice syokuzai)
    {
		m_SyokuzaiNames[(int)m_Gauge] = syokuzai.SyokuzaiName;

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
		if(y<=0){
			m_Water.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
		}else{
        	m_Water.transform.localScale = new Vector3(0.8f, y, 0.8f);
			m_Water.transform.localPosition = new Vector3(0, 0.5f * y-0.5f, 0);
		}
    }

	void CutInCheck(){

		string marimo = "marimo";
		string Any = "Any";

		string[,] Special = new string[1,3]{
			{marimo,Any,Any},
		};
		for(int i=0;i<1;i++){
			bool flag = true;
			flag = flag&&Check(Special[i,0]);
			flag = flag&&Check(Special[i,1]);
			flag = flag&&Check(Special[i,2]);
			if(flag){
				Instantiate(m_CutIn[i]);
				break;
			}
		}

	}

	bool Check(string s){
		if(s=="Any")return true;
		for(int i=0;i<3;i++){
			if(s == m_SyokuzaiNames[i]){
				m_SyokuzaiNames[i] = "";
				return true;
			}
		}
		return false;
	}

}