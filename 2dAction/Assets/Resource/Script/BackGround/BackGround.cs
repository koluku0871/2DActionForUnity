using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {
	public Sprite[] book = new Sprite[22];
	public int index = 0;
	SpriteRenderer mainSpriteRenderer;

	public void Start () {
		mainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	public void Update () {
		mainSpriteRenderer.sprite = book[index];
		index++;
		if (index >= 22)
		{
			index = 0;
		}
	}
}
