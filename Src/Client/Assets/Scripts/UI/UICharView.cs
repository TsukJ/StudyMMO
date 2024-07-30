using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharView : MonoBehaviour {

    public GameObject[] classesObj;

    private int currentCharacter = 0;

    public int CurrectCharacter
    {
        get
        {
            return currentCharacter;
        }
        set
        {
            currentCharacter = value;
            this.showCharacter();
        }
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showCharacter()
    {
        int len = classesObj.Length;
        for (int i = 0; i < len; i++)
        {
            classesObj[i].SetActive(i == this.currentCharacter);
        }
    }
}
