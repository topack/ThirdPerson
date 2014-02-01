using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	public Character Player;
	public Icon Icon1;
	public Icon Icon2;
	public Spell FireBall;
	public SpellIce Frostnova;
	
	public void Awake()
	{
		FireBall = new Spell();
		FireBall.Id = 1;
		FireBall.Name = "Fireball";
		FireBall.IconTexture = Resources.Load<Texture>("Icons/Spell_fire_fireball02");

		Frostnova = new SpellIce();
		Frostnova.Id = 2;
		Frostnova.Name = "Frostnova";
		Frostnova.IconTexture = Resources.Load<Texture>("Spell_frost_frostnova");

		FireBall.Effects.Add(Frostnova);

		Icon1.Player = Player;
		Icon2.Player = Player;
		Icon1.SetSpell(FireBall);
		Icon2.SetSpell(Frostnova);
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
