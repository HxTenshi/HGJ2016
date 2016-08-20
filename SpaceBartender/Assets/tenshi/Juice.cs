using UnityEngine;
using System.Collections;

public class Juice : MonoBehaviour {


	int m_SyokuzaiType;
	public int SyokuzaiType{
		get {return m_SyokuzaiType;}
		set {m_SyokuzaiType = value;}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeMaterial(Color material)
    {
        var mat = GetComponent<Renderer>();
		mat.material.color = material;
    }

    void OnTriggerEnter(Collider other)
    {
        Cop cop = other.gameObject.GetComponent<Cop>();
        if (cop)
        {
			
			cop.AddSyokuzai(this);
            DestroyObject(gameObject);
        }

    }
}
