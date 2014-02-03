using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

	public Transform tr;
	public GUITexture texture;

	void Awake()
	{
		texture = this.gameObject.GetComponent<GUITexture>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint(tr.position);

		texture.pixelInset = new Rect(screenPos.x, Screen.height - screenPos.y, 20, 20);
	}
}
