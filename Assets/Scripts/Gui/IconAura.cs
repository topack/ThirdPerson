using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(GUIText))]
public class IconAura : MonoBehaviour
{
	public Transform Transform;
	public GUITexture GuiTexture;
	public GUIText GuiText;
	public Texture DefaultTexture;
	public Vector2 Position;
	public SpellPrefab SpellPrefab;

	private Vector3 screenPos;
	private Vector2 iconSize;
	
	void Awake()
	{
		GuiTexture = this.gameObject.GetComponent<GUITexture>();
		GuiText = this.gameObject.GetComponent<GUIText>();
	}
	
	void FixedUpdate ()
	{
		screenPos = Camera.main.WorldToScreenPoint(Transform.position);

		Debug.Log(screenPos.x + " : " + screenPos.y);

		GuiTexture.pixelInset = new Rect(screenPos.x + Position.x, screenPos.y + Position.y, iconSize.x, iconSize.y);
		GuiText.pixelOffset = new Vector2(screenPos.x + 2, screenPos.y + 2);

		GuiText.text = SpellPrefab.Cooldown - SpellPrefab.Duration;
	}
	
	public void SetSpellPrefab(SpellPrefab spellPrefab)
	{
		SpellPrefab = spellPrefab;
		if(SpellPrefab != null)
		{
			//guiText = (SpellPrefab.Duration - SpellPrefab.TotalDuration).toString();
		}
		
		if(SpellPrefab != null && SpellPrefab.IconTexture != null)
		{
			GuiTexture.texture = SpellPrefab.IconTexture;
			GuiText.text = SpellPrefab.Cooldown - SpellPrefab.Duration;
		}
		else
		{
			GuiTexture.texture = DefaultTexture;
			GuiText.text = string.Empty;
		}
	}
	
	public void SetIconSize(Vector2 iconSize)
	{
		this.iconSize = iconSize;
	}
}
