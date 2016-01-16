using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public Text timeObj;
	private float timeCount = 3 * 60;

	public void Start()
	{
	}

	public void Update()
	{
		timeCount -= 1f * Time.deltaTime;
		timeObj.text = ((int)timeCount).ToString();
	}
}
