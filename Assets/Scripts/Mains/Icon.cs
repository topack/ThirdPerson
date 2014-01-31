using UnityEngine;
using System.Collections.Generic;

public class SpellButton : MonoBehaviour
{
	#region Declaration
	public bool Active;
	public bool Clickable;
	public Vector2 Size;
	public Vector2 Position;
	public Texture DefaultTexture
	public Character Player
	
	private Texture Texture;
	private Spell Spell
	#endregion

	public Icon (Character player, Spell spell)
	{
		Spell = spell;
		Player = player;
	}

	public void OnGUI()
	{
		if (GUI.Button(Rect(Size.x,Size.y,Position.x,Position.y), Texture))
		{
			Click();
		}
	}
	
	public AddSpell(Spell spell)
	{
		if(spell != null && spell.Texture != null)
		{
			Texture = spell.Texture
		}
		else
		{
			Texture = DefaultTexture;
		}
	}
	
	public Click()
	{
		spell.Cast(Player.Gameobject, Player.Target);
	}
	
	public Drag(Vector2 position)
	{
		Clickable = false;
		Position = position;
	}
	
	public Drop()
	{
		Clickable = true;
	}
}
