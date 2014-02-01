using UnityEngine;
using System.Collections.Generic;

public class Icon : MonoBehaviour
{
	public bool Active;
	public bool Clickable;
	public Vector2 Size;
	public Vector2 Position;
	public Texture DefaultTexture;
	public Character Player;
	public Spell Spell;

	private Texture IconTexture;

	void OnGUI()
	{
		if (GUI.Button(new Rect(Position.x, Position.y, Size.x, Size.y), IconTexture))
		{
			Click();
		}
	}

	public void SetSpell(Spell spell)
	{
		Spell = spell;
		if(spell != null && spell.IconTexture != null)
		{
			IconTexture = spell.IconTexture;
		}
		else
		{
			IconTexture = DefaultTexture;
		}
	}

	public void Click()
	{
		Spell.Cast(Player.gameObject, Player.Target);
	}
	
	public void Drag(Vector2 position)
	{
		Clickable = false;
		Position = position;
	}
	
	public void Drop()
	{
		Clickable = true;
	}
}
