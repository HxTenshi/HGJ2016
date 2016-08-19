using UnityEngine;
using System.Collections;

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

	[SerializeField]
	Color m_JuiceColor;

    [SerializeField]
    float m_BreakPower;
    float m_BreakPower_Count;
    
    // Use this for initialization
    void Start () {
        m_BreakPower_Count = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hineri(float power)
    {
		m_BreakPower_Count += power;

		float hineri = m_BreakPower_Count / m_BreakPower;

		GetComponent<Renderer>().material.SetFloat("_Hineri", hineri * 10);

        if (m_BreakPower_Count >= m_BreakPower)
        {
            GetComponent<Renderer>().material.SetFloat("_Hineri", 0);

            var juice = Instantiate(m_Juice);
            juice.transform.position = transform.position;

            var ren = gameObject.GetComponent<Renderer>();
			var j = juice.GetComponent<Juice>();
			j.ChangeMaterial(m_JuiceColor);
			j.SyokuzaiType = (int)m_Type;

            DestroyObject(gameObject);
        }
    }

    public bool IsBreak()
    {
        return m_BreakPower_Count >= m_BreakPower;
    }
}
