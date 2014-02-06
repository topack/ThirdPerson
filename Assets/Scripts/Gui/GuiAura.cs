using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(GUIText))]
public class GuiAura : MonoBehaviour
{
	private GUITexture guiAuraTexture;
	private GUIText guiLabel;

	void Awake()
	{
		guiAuraTexture = this.gameObject.GetComponent<GUITexture>();
		guiLabel.transform.position = Vector3.zero;
		guiLabel = this.gameObject.GetComponent<GUIText>();
		guiLabel.transform.position = new Vector3(0,0,1);
	}

	public void UpdateGuiAura(Vector2 position, Vector2 size, Texture texture, string text)
	{
		guiAuraTexture.pixelInset = new Rect(position.x, position.y, size.x, size.y);
		guiLabel.pixelOffset = new Vector2(position.x + (size.x / 2), position.y + (size.y / 2));
		guiAuraTexture.texture = texture;
		guiLabel.text = text;
	}

	public void UpdateText(string text)
	{
		this.guiLabel.text = text;
	}
}
