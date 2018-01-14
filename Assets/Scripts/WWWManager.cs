using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WWWManager : MonoBehaviour {

    public string url = "http://127.0.0.1:8000/get/data";

    public Text outputText = null;

    public void SetNewURL(string newUrl)
    {
        url = newUrl;
    }
	
	IEnumerator GetSite()
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.text);
        outputText.text = www.text;
        www.Dispose();

    }

    public void Connect()
    {
        Debug.Log("Connect to: "+ url);
        StartCoroutine(GetSite());
    }


}
