using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
using SkillBridge.Message;
using UnityEngine.SceneManagement;

public class UIRegister : MonoBehaviour {

    public InputField username;
    public InputField password;
    public InputField passwordConfirm;
    public Button buttonRegister;
    public Toggle toggleRead;


    // Use this for initialization
    void Start () {
        UserService.Instance.OnRegister = this.OnRegister;
    }

    void OnRegister(Result result,string msg)
    {
        if (result == Result.Success)
        {
            UserService.Instance.SendLogin(this.username.text, this.password.text);
        }
        else
        {
            MessageBox.Show(string.Format("结果：{0} 信息：{1}", result, msg));
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickRegister()
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输入用户名");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        if (string.IsNullOrEmpty(this.passwordConfirm.text))
        {
            MessageBox.Show("请输入二次确认密码");
            return;
        }
        if (this.password.text != this.passwordConfirm.text)
        {
            MessageBox.Show("两次输入密码不相同");
            return;
        }
        if (this.toggleRead.isOn == false)
        {
            MessageBox.Show("未同意《用户协议》");
            return;
        }
        UserService.Instance.SendRegister(this.username.text, this.password.text);

    }
}
