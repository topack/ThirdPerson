using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	public Character Player;
	public Icon Icon;
	
	public void Start()
	{
		Icon = new GameObject("SpellIcon1", Icon) as Icon;
		Icon.Player = Player;
		Icon.Spell = new Spell(1);
	}
	
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Player.AddSpell(Icon.Spell);
			Player.AddSpell(new SpellIce(2));
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			Player.CastSpell(1);
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			Player.CastSpell(2);
		}
	}
}
