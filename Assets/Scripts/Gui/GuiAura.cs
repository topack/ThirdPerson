using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(GUIText))]
public class GuiAura : MonoBehaviour
{	
	public Texture DefaultTexture;

	private Vector2 size;
	private Vector2 positionOffset;
	private bool followTransform;
	private Vector2 positionOnScreen;
	private Transform transformToFollow;
	private SpellPrefab spellPrefab;
	private GUITexture guiAuraTexture;
	private GUIText guiLabel;

	void Awake()
	{
		guiAuraTexture = this.gameObject.GetComponent<GUITexture>();
		guiLabel = this.gameObject.GetComponent<GUIText>();
	}

	public void Init(Vector2 size, Vector2 positionOffset, bool followTransform, Vector2 positionOnScreen, Transform transformToFollow, SpellPrefab spellPrefab)
	{
		this.size = size;
		this.positionOffset = positionOffset;
		this.followTransform = followTransform;
		this.positionOnScreen = positionOnScreen;
		this.transformToFollow = transformToFollow;
		this.spellPrefab = spellPrefab;
		if (this.spellPrefab == null || this.spellPrefab.IconTexture == null)
		{
			this.guiAuraTexture.texture = Main.DefaultTexture;
		}
		else
		{
			this.guiAuraTexture.texture = this.spellPrefab.IconTexture;
		}
	}

	void FixedUpdate ()
	{
		if (followTransform && transformToFollow != null)
		{
			screenPos = Camera.main.WorldToScreenPoint(transformToFollow.position);
		}
		else
		{
			screenPos = Vector3.zero;
		}

		if(!followTransform)
		{
			screenPos = positionOnScreen;
		}

		guiAuraTexture.pixelInset = new Rect(screenPos.x + positionOffset.x, screenPos.y + positionOffset.y, size.x, size.y);
		guiLabel.pixelOffset = new Vector2(screenPos.x + positionOffset.x + 2, screenPos.y + positionOffset.y + 2);

		guiLabel.text = Mathf.CeilToInt(spellPrefab.Duration - spellPrefab.TotalDuration).ToString();
	}

	public void UpdatePositionOffset(Vector2 positionOffset)
	{
		this.positionOffset = positionOffset;
	}

	public void UpdateText(string text)
	{
		this.guiLabel.text = text;
	}
}
