using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menseki : MonoBehaviour {

    public GameObject gameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MensekiEvent(){
        gameObject.SetActive(true);
    }
}
