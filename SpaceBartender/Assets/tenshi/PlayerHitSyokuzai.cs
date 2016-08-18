using UnityEngine;
using System.Collections;

public class PlayerHitSyokuzai : MonoBehaviour {

    [SerializeField]
    GameObject m_SelectSyokuzai;

    [SerializeField]
    GameObject m_SelectCop;

    public GameObject SelectSyokuzai
    {
        get { return m_SelectSyokuzai; }
    }

	// Use this for initialization
	void Start () {
        m_SelectSyokuzai = null;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        Syokuzai s = other.gameObject.GetComponent<Syokuzai>();
        if (s)
        {
            m_SelectSyokuzai = s.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Syokuzai s = other.gameObject.GetComponent<Syokuzai>();
        if (s&&m_SelectSyokuzai == s.gameObject)
        {
            m_SelectSyokuzai = null;
        }
    }
}
