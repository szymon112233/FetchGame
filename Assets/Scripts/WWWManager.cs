using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWManager : MonoBehaviour {

    public string url = "http://192.168.0.199:8000/";


    // Use this for initialization
    void Start () {
        StartCoroutine(GetSite());
	}
	
	IEnumerator GetSite()
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.text);
        www.Dispose();

    }
}
