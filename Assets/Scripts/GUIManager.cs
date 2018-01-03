using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text HpText;
    public PlayerMovment player;
	
	// Update is called once per frame
	void Update () {
        HpText.text = string.Format("HP: {0}", player.CurrentHP);
	}
}
