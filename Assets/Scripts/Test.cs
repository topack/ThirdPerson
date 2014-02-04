using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

	public Transform tr;
	public GUITexture guiTexture;
	public GUIText guiText;

	void Awake()
	{
		guiTexture = this.gameObject.GetComponent<GUITexture>();
		guiText = this.gameObject.GetComponent<GUIText>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint(tr.position);
		
		guiTexture.pixelInset = new Rect(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2, 20, 20);
		guiText.pixelInset = new Rect(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2, 20, 20);
	}
}
