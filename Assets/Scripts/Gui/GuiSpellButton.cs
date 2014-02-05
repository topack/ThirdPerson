using UnityEngine;

public class GuiSpellButton : MonoBehaviour
{
	private Character character;
	private Spell spell;
	private Vector2 size;
	private Vector2 position;	
	private Texture texture;

	public void Init(Character character, Spell spell, Vector2 size, Vector2 position)
	{
		this.character = character;
		this.spell = spell;
		this.size = size;
		this.position = position;

		UpdateTexture();
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(position.x, position.y, size.x, size.y), texture))
		{
			Click();
		}
	}

	public void Click()
	{
		spell.Cast(character.gameObject, character.Target);
	}
	
	public void Drag(Vector2 position)
	{
	}
	
	public void Drop()
	{
	}

	#region private
	private void UpdateTexture()
	{
		texture = Main.DefaultAuraTexture;
		if (spell != null && spell.IconTexture != null)
		{
			texture = spell.IconTexture;
		}
	}
	#endregion
}
