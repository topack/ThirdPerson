using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
[RequireComponent(typeof(guiText))]
public class IconSpell : MonoBehaviour
{
	public Transform transform;
	public GUITexture guiTexture;
	public GUIText guiText;
	public Texture DefaultTexture;
	public SpellPrefab SpellPrefab;

	private Vector3 screenPos;
	private Vector2 iconSize;
	
	void Awake()
	{
		guiTexture = this.gameObject.GetComponent<GUITexture>();
		guiText = this.gameObject.GetComponent<GUIText>();
	}
	
	void Update ()
	{
		screenPos = Camera.main.WorldToScreenPoint(transform.position);
		
		guiTexture.pixelInset = new Rect(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2, iconSize.x, iconSize.y);
		guiText.pixelInset = new Rect(screenPos.x - Screen.width / 2, screenPos.y - Screen.height / 2, iconSize.x, iconSize.y);
	}
	
	public void SetSpellPrefab(SpellPrefab spellPrefab)
	{
		SpellPrefab = spellPrefab;
		if(SpellPrefab != null)
		{
			transform = SpellPrefab.gameObject.find("SpellAuras");
			guiText = (SpellPrefab.Duration - SpellPrefab.TotalDuration).toString();
		}
		
		if(SpellPrefab != null && SpellPrefab.IconTexture != null)
		{
			guiTexture = SpellPrefab.IconTexture;
		}
		else
		{
			guiTexture = DefaultTexture;
		}
	}
	
	public void SetIconSize(Vector2 iconSize)
	{
		this.iconSize = iconSize;
	}
}
