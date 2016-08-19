using UnityEngine;
using System.Collections;

public class Syokuzai : MonoBehaviour {

    [SerializeField]
    GameObject m_Juice;
    public int m_Type;

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

    public void Hineri()
    {
        m_BreakPower_Count += 1.0f;


        GetComponent<Renderer>().material.SetFloat("_Hineri", m_BreakPower_Count * 10);

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
