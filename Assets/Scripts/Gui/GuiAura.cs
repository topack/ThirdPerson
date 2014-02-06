using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(GUIText))]
public class GuiAura : MonoBehaviour
{
	/// <summary>
	/// Component GUITexture present on the same GameObject
	/// </summary>
	private GUITexture guiAuraTexture;
	/// <summary>
	/// Component GUIText present on the same GameObject
	/// </summary>
	private GUIText guiLabel;

	void Awake()
	{
		// get the GUITexture and GUIText components
		// change GUIText position to render in front of the GUITexture
		guiAuraTexture = this.gameObject.GetComponent<GUITexture>();
		guiLabel.transform.position = Vector3.zero;
		guiLabel = this.gameObject.GetComponent<GUIText>();
		guiLabel.transform.position = new Vector3(0,0,1);
	}

	/// <summary>
	/// Update the aura position, size, texture and text
	/// </summary>
	/// <param name="position">on screen position of the aura</param>
	/// <param name="size">size of the texture</param>
	/// <param name="texture">texture to display</param>
	/// <param name="text">text of the label</param>
	public void UpdateGuiAura(Vector2 position, Vector2 size, Texture texture, string text)
	{
		guiAuraTexture.pixelInset = new Rect(position.x, position.y, size.x, size.y);
		guiLabel.pixelOffset = new Vector2(position.x + (size.x / 2), position.y + (size.y / 2));
		guiAuraTexture.texture = texture;
		guiLabel.text = text;
	}

	/// <summary>
	/// Update the aura label
	/// </summary>
	/// <param name="text">text of the label</param>
	public void UpdateText(string text)
	{
		this.guiLabel.text = text;
	}
}
