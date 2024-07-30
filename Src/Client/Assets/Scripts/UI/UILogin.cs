using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Services;
using SkillBridge.Message;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {

	public InputField user;
	public InputField password;
	public Button buttonLogin;
	public SceneManager sceneManager;

	// Use this for initialization
	void Start () {
		UserService.Instance.OnLogin = this.OnLogin;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickLogin()
	{
        UserService.Instance.SendLogin(this.user.text, this.password.text);
    }

	public void OnLogin(Result result, string msg)
	{
		if (result == Result.Success)
		{
			sceneManager.LoadScene("CharSelect");
        }
		else
		{
            MessageBox.Show(string.Format("登陆失败【{0}】",msg));
        }
	}
}
