using UnityEngine;
using System.Collections;

public class Syokuzai : MonoBehaviour {

    [SerializeField]
    GameObject m_Juice;

	[SerializeField]
	int m_Type;

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
            juice.GetComponent<Juice>().ChangeMaterial(ren.material);

            DestroyObject(gameObject);
        }
    }

    public bool IsBreak()
    {
        return m_BreakPower_Count >= m_BreakPower;
    }
}
