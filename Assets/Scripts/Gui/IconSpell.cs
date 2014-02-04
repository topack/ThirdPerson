using UnityEngine;
using System.Collections.Generic;

public class IconSpell: MonoBehaviour
{
	public Vector2 Size;
	public Vector2 Position;
	public Texture DefaultTexture;
	public SpellPrefab SpellPrefab;

	private Texture IconTexture;

	public void SetSpell(SpellPrefab spellPrefab)
	{
		SpellPrefab = spellPrefab;
		if(SpellPrefab != null && SpellPrefab.IconTexture != null)
		{
			IconTexture = SpellPrefab.IconTexture;
		}
		else
		{
			IconTexture = DefaultTexture;
		}
	}
}
