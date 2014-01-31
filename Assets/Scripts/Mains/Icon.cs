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
	public GameObject SpellObject
	
	private Spell Spell;
	private Texture Texture;
	#endregion
	
	public void Awake()
	{
		AddSpell(SpellObject);
	}

	public void OnGUI()
	{
		if (GUI.Button(Rect(Size.x,Size.y,Position.x,Position.y), Texture))
		{
			Click();
		}
	}
	
	public AddSpell(GameObject gameObject)
	{
		Spell = gameObject.GetComponent<Spell>();
		if(Spell != null && Spell.Texture != null)
		{
			Texture = Spell.Texture
		}
		else
		{
			Texture = DefaultTexture;
		}
	}
	
	public Click()
	{
		spell.Cast();
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
