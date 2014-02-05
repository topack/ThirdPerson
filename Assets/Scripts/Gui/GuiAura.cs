using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(GUIText))]
public class GuiAura : MonoBehaviour
{	
	public Texture DefaultTexture;

	private Vector2 size;
	private Vector2 positionOffset;
	private Transform transformToFollow;
	private GUITexture texture;
	private GUIText text;
	private Vector3 screenPos;

	void Awake()
	{
		texture = this.gameObject.GetComponent<GUITexture>();
		text = this.gameObject.GetComponent<GUIText>();
	}

	public void Init(Vector2 size, Vector2 positionOffset, Transform transformToFollow, Texture texture)
	{
		this.size = size;
		this.positionOffset = positionOffset;
		this.transformToFollow = transformToFollow;
		this.texture.texture = texture;
		if (this.texture.texture == null)
		{
			this.texture.texture = Main.DefaultAuraTexture;
		}
	}

	void FixedUpdate ()
	{
		if (transformToFollow != null)
		{
			screenPos = Camera.main.WorldToScreenPoint(transformToFollow.position);
		}
		else
		{
			screenPos = Vector3.zero;
		}

		texture.pixelInset = new Rect(screenPos.x + positionOffset.x, screenPos.y + positionOffset.y, size.x, size.y);
		text.pixelOffset = new Vector2(screenPos.x + positionOffset.x + 2, screenPos.y + positionOffset.y + 2);
	}

	public void UpdatePositionOffset(Vector2 positionOffset)
	{
		this.positionOffset = positionOffset;
	}

	public void UpdateText(string text)
	{
		this.text.text = text;
	}
}
