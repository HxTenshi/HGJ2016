using UnityEngine;
using System.Collections;

public class Syokuzai : MonoBehaviour {

    [SerializeField]
    GameObject m_Juice;
    public int m_Type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Hineri()
    {
        var juice = Instantiate(m_Juice);
        juice.transform.position = transform.position;
        DestroyObject(gameObject);
    }
}
