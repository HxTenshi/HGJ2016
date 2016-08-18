﻿using UnityEngine;
using System.Collections;

public class Juice : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
