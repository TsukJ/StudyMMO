using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharSelect : MonoBehaviour {

	public SceneManager sceneManager;
	public Button buttonBack;
	public int selectedCharacter;

	public GameObject selectPanel;
	public GameObject createPanel;
	public UICharView charViewScripts;
    protected UICharCreate charCreateScripts;

    // Use this for initialization
    void Start () {
        charCreateScripts = createPanel.GetComponent<UICharCreate>();
        charViewScripts.CurrectCharacter = getClassesNumFromCharacter(selectedCharacter);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onBack()
	{
		Debug.Log(createPanel.activeSelf);
		if (createPanel.activeSelf)
		{
            selectPanel.SetActive(true);
            createPanel.SetActive(false);
            charViewScripts.CurrectCharacter = getClassesNumFromCharacter(selectedCharacter);
        }
		else
		{
            sceneManager.LoadScene("Login");
        }
    }

	public int getClassesNumFromCharacter(int selectedCharacter)
	{
		return -1;
	}

	public void onClickSelectCharacter(int slotNum)
	{
		Debug.Log(slotNum);
		if (false)
		{
			this.selectedCharacter = slotNum;
            charViewScripts.CurrectCharacter = getClassesNumFromCharacter(selectedCharacter);
        }
		else
		{
			selectPanel.SetActive(false);
			createPanel.SetActive(true);
			charCreateScripts.showClassDetails();
        }
	}
}
