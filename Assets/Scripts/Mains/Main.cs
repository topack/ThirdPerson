using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	public static Character Player;
	public static float GlobalCoolDownTimer;
	public Character Player2;
	public GuiSpellButton Icon1;
	public GuiSpellButton Icon2;
	public Spell FireBall;
	public Spell Frostnova;
	public static Texture DefaultTexture = Resources.Load<Texture>("Icons/Inv_misc_questionmark");
	public static string PrefabGuiSpellButton = "Prefabs/Gui/GuiSpellButton";
	public static string PrefabGuiAura = "Prefabs/Gui/GuiAura";
	
	public void Awake()
	{
		// Get the player for static use
		Player = GameObject.Find("Character1").GetComponent<Character>();
		Player2 = GameObject.Find("Character2").GetComponent<Character>();

		// load spell config
		FireBall = new Spell();
		FireBall.Id = 1;
		FireBall.Name = "Fireball";
		FireBall.AuraTexture = Resources.Load<Texture>("Icons/Spell_fire_fireball02");
		FireBall.Prefab = "Prefabs/Spells/SpellFireball";
		FireBall.Value = 1;
		FireBall.CastTime = 10;
		FireBall.Cooldown = 15;
		FireBall.GlobalCooldown = 1;
		FireBall.Range = 2;
		FireBall.Effects.Add(
			new Spell
			{
			Id = 3,
			Name = "Dot",
			AuraTexture = Resources.Load<Texture>("Icons/Spell_fire_fireball02"),
			Prefab = "Prefabs/Spells/SpellFireDot",
			Value = 2,
			Duration = 15,
			TickTimer = 1,
			PassiveSpell = true,
			StartTickingAtAuraApplication = false,
			IsEffect = true
			}
		);
		
		Frostnova = new Spell();
		Frostnova.Id = 2;
		Frostnova.Name = "Frostnova";
		Frostnova.AuraTexture = Resources.Load<Texture>("Icons/Spell_frost_frostnova");
		Frostnova.Duration = 3;
		Frostnova.Value = 4;
		Frostnova.SelfSpell = true;

		// add spell to player spell book
		Player.SpellBook.Add(FireBall);
		Player.SpellBook.Add(Frostnova);

		// Init Icon and Set Spell from spellBook
		Object prefabGuiSpellButton = Resources.Load(Main.PrefabGuiSpellButton);
		if (prefabGuiSpellButton != null)
		{
			GameObject iconObj = GameObject.Instantiate(prefabGuiSpellButton, Vector3.zero, Quaternion.identity) as GameObject;
			Icon1 = iconObj.GetComponent<GuiSpellButton>();
			Icon1.Init(Player, Player.SpellBook[0], new Vector2(50, 50), new Vector2(0,0));

			iconObj = GameObject.Instantiate(prefabGuiSpellButton, Vector3.zero, Quaternion.identity) as GameObject;
			Icon2 = iconObj.GetComponent<GuiSpellButton>();
			Icon2.Init(Player, Player.SpellBook[1], new Vector2(50, 50), new Vector2(55, 0));
		}
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

	public void FixedUpdate()
	{
		// decrease the GlobalCoolDown
		if(GlobalCoolDownTimer > 0)
		{
			GlobalCoolDownTimer -= Time.deltaTime;
		}
	}
}
