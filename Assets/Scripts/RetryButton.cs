using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour {

    public GameObject gameObject;
    public CSVRader cSVRader;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FalseResultPanel(){
        gameObject.SetActive(false);
        cSVRader.countTime = 0.0f;
    }
}
