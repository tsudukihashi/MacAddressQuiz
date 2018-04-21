using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour {

    public CSVRader csvReader;

    public void JudgeAnswer(){
        Text selectBtn = this.GetComponentInChildren<Text>();
        //Debug.Log(selectBtn.text);
        //Debug.Log(csvReader.CheckText());
        if(selectBtn.text == csvReader.CheckText().Trim('"')){
            csvReader.correct();
        }else{
            csvReader.incorrect();
        }
    }
}
