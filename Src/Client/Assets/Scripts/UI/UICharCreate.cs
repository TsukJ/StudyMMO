using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;

public class UICharCreate : MonoBehaviour {

    public GameObject charView;
    protected UICharView charViewScripts;

    public int selectedClassNum;
    public string className;
    public Text descs;
    public InputField nameInput;

    // Use this for initialization
    void Start () {
        charViewScripts = charView.GetComponent<UICharView>();
        showClassDetails();
        UserService.Instance.OnCharacterCreate = OnCharacterCreate;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickCreateCharacter()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            MessageBox.Show("昵称不能为空");
            return;
        }

        UserService.Instance.SendCharacterCreate(this.nameInput.text, (CharacterClass)(this.selectedClassNum+1));
    }

    void OnCharacterCreate(Result result, string message)
    {
        if (result == Result.Success)
        {
            MessageBox.Show(message, "错误", MessageBoxType.Error);

        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }

    public void onClickSelectClass(int slotNum)
    {
        selectedClassNum = slotNum;
        showClassDetails();
    }

    public void showClassDetails()
    {
        if (charViewScripts != null)
        {
            charViewScripts.CurrectCharacter = selectedClassNum;
            className = DataManager.Instance.Characters[selectedClassNum + 1].Name;
            string txt = DataManager.Instance.Characters[selectedClassNum + 1].Description;
            descs.text = string.Format("{0}\n\n{1}",className,txt);
        }
        // showDescriptions();
    }
}
