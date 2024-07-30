using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using SkillBridge.Message;
using ProtoBuf;
using System;
using UnityEngine.SceneManagement;

public class Loading_logic : MonoBehaviour {

	public GameObject suggestion;
	public GameObject loading;
	public SceneManager sceneManager;

	public Slider process;
	public Text processNum;
	public Text processText;


	// Use this for initialization
	IEnumerator Start () {
        log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.xml"));
		UnityLogger.Init();

		suggestion.SetActive(true);
		yield return new WaitForSeconds(2f);
		suggestion.SetActive(false);

        yield return DataManager.Instance.LoadData();

        for (float i = 0; i < 100;)
		{
			i += UnityEngine.Random.Range(0.1f, 1f);
			if (i > 100)
			{
				sceneManager.LoadScene("Login");
                i = 100;
			}
			process.value = i;
			processNum.text = i.ToString("F0")+"%";
			yield return new WaitForEndOfFrame();
		}

		// sceneManager.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
