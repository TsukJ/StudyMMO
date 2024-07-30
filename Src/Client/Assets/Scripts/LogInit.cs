using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.xml"));
        UnityLogger.Init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
