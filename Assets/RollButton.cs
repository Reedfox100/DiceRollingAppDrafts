using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    public Button rollButton;

	void Start () {
		Button btn = rollButton.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick(){
		Debug.Log ("You have clicked the button!");
	}
}
