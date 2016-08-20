using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Syokuzai : MonoBehaviour {

    [SerializeField]
    GameObject m_Juice;

	enum SyokuzaiType{
		Alien = 1,
		Human = 2,
		Kemono = 4,
		Gyojin = 8,
		Robot = 16,
	}
	[SerializeField]
	SyokuzaiType m_Type;

	int m_SyokuzaiNum = 1;

	[SerializeField]
	Color m_JuiceColor;

    [SerializeField]
	float m_BreakPower;
	float m_BreakPower_Back;
    float m_BreakPower_Count;
    
    // Use this for initialization
    void Start () {
        m_BreakPower_Count = 0.0f;
		m_BreakPower_Back = m_BreakPower;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddSyokuzaiNum(int num){
		
		List<GameObject> objs = new List<GameObject>();
		for(int i=0;i<num;i++){
			objs.Add(Instantiate(gameObject));
		}

		float y = 0;
		foreach(GameObject child in objs){
			y+=0.25f;
			child.transform.position += new Vector3(0,y,0);
			m_SyokuzaiNum++;
			child.transform.parent = gameObject.transform;

			DestroyObject(child.GetComponent<Rigidbody>());
			DestroyObject(child.GetComponent<BoxCollider>());
		}
	}


	public void Hineri(float power)
    {
		m_BreakPower_Count += power;

		float hineri = m_BreakPower_Count / m_BreakPower;

		GetComponent<Renderer>().material.SetFloat("_Hineri", hineri * 10);

		if (m_BreakPower_Count >= m_BreakPower_Back)
        {
            GetComponent<Renderer>().material.SetFloat("_Hineri", 0);

            var juice = Instantiate(m_Juice);
            juice.transform.position = transform.position;

            var ren = gameObject.GetComponent<Renderer>();
			var j = juice.GetComponent<Juice>();
			j.ChangeMaterial(m_JuiceColor);
			j.SyokuzaiType = (int)m_Type;

			m_SyokuzaiNum--;

			if(m_SyokuzaiNum<=0){
            	DestroyObject(gameObject);
			}else{
				m_BreakPower_Back += m_BreakPower;
			}
        }

		foreach(Transform child in transform){
			child.gameObject.GetComponent<Syokuzai>().HineriOnly(power);
		}
    }

	public void HineriOnly(float power)
	{
		m_BreakPower_Count += power;

		float hineri = m_BreakPower_Count / m_BreakPower;

		GetComponent<Renderer>().material.SetFloat("_Hineri", hineri * 10);
	}

    public bool IsBreak()
    {
		return m_BreakPower_Count >= m_BreakPower_Back;
    }
}
