using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenseki : MonoBehaviour {

    public GameObject gameObject;

    public void ReturnGame(){
        gameObject.SetActive(false);
    }
}
