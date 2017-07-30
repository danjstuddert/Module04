using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController> {
	public Text lifeSupportText;
	public Text lifeSupportTextDark;

	private int lifeSupportAmount;
	private string originalText;

	// Use this for initialization
	void Start () {
		originalText = lifeSupportText.text;
		lifeSupportAmount = int.MaxValue;
	}

	public void UpdateLifeSupportText(float amount) {
		int roundAmount = (int)amount / 10;

		if (roundAmount < 0)
			return;

		if(roundAmount < lifeSupportAmount) {
			lifeSupportAmount = roundAmount;
			lifeSupportText.text = string.Format("{0} {1}%", originalText, lifeSupportAmount);
			lifeSupportTextDark.text = string.Format("{0} {1}%", originalText, lifeSupportAmount);
		}
	}
}
