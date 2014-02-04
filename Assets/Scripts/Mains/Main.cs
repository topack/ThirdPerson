using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	public static Character Player;
	public Icon Icon1;
	public Icon Icon2;
	public Spell FireBall;
	public Spell Frostnova;
	
	public void Awake()
	{
		// Get the player for static use
		Player = GameObject.Find("Character1").GetComponent<Character>();

		// load spell config
		FireBall = new Spell();
		FireBall.Id = 1;
		FireBall.Name = "Fireball";
		FireBall.IconTexture = Resources.Load<Texture>("Icons/Spell_fire_fireball02");
		FireBall.Prefab = "Prefabs/Spells/SpellFireball";
		FireBall.Value = 1;
		FireBall.Effects.Add(
			new Spell
			{
			Id = 3,
			Name = "Dot",
			IconTexture = Resources.Load<Texture>("Icons/Spell_fire_fireball02"),
			Prefab = "Prefabs/Spells/SpellFireDot",
			Value = 2,
			Duration = 5,
			TickTimer = 1,
			StartTickingAtAuraApplication = false
			}
		);
		
		Frostnova = new Spell();
		Frostnova.Id = 2;
		Frostnova.Name = "Frostnova";
		Frostnova.IconTexture = Resources.Load<Texture>("Icons/Spell_frost_frostnova");
		Frostnova.Duration = 3;
		Frostnova.Value = 4;

		// add spell to plaier spell book
		Player.SpellBook.Add(FireBall);
		Player.SpellBook.Add(Frostnova);

		// Init Icon and Set Spell from spellBook
		Icon1.Player = Player;
		Icon2.Player = Player;
		Icon1.SetSpell(Player.SpellBook[0]);
		Icon2.SetSpell(Player.SpellBook[1]);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Icon1.Click();
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Icon2.Click();
		}
	}
}
