using System.Collections;
using System;
using System.Runtime;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    public Button rollButton;

	void Start () {
		Button btn = rollButton.GetComponent<Button>();
		GameObject.Instantiate(GameObject.Find("node_id4"));
		GameObject.Instantiate(GameObject.Find("node_id4"));
		GameObject.Instantiate(GameObject.Find("node_id4"));
		GameObject.Instantiate(GameObject.Find("node_id4"));
		GameObject.Instantiate(GameObject.Find("node_id4"));
		btn.onClick.AddListener(OnClick);
	}

	void OnClick(){
        throw new Exception("Excepted");
		Debug.Log ("You have clicked the button!");
	}
}
