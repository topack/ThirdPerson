using UnityEngine;
using System.Collections.Generic;

public class Spell
{
	#region Declaration
	public int Id;
	public string Name;
	public Texture AuraTexture;
	public string Prefab;		// prefab of the spell for 3D render
	public int Value;
	public int Range;			// (0==self)
	public int CastTime;		// (instant == 0, channel < 0, cast > 0)
	public int Duration;
	public int TickTimer;
	public int Cooldown;
	public int GlobalCooldown;
	public SchoolType School;
	public MechanicType Mechanic;
	public DispellType DispellType;
	public bool CannotBeUsedInCombat;
	public bool CannotBeUsedWhileShapeshifted;
	public bool PassiveSpell;
	public bool HideAura;
	public bool StartTickingAtAuraApplication;
	public List<Spell> Effects = new List<Spell>();
	#endregion

	public Spell(){}

	public Spell(int spellId)
	{
		Id = spellId;
		InitialiseSpell();
	}
	
	/// <summary>
	/// Initialise the spell with the DB data
	/// </summary>
	protected void InitialiseSpell()
	{
		
	}

	/// <summary>
	/// Casts the spell on the target
	/// </summary>
	public virtual void Cast(GameObject caster, GameObject target)
	{
		if(target == null)
		{
			Debug.Log("No target selected");
			return;
		}

		Debug.Log(string.Format("Cast spell : {0}", Name));

		Apply(caster, target);
	}

	/// <summary>
	/// Apply the spell
	/// </summary>
	/// <param name="caster">caster of the spell</param>
	/// <param name="target">target of the spell</param>
	protected virtual void Apply(GameObject caster, GameObject target)
	{
		CreatePrefab(caster, target);
	}

	/// <summary>
	/// Create the prefab of the spell
	/// </summary>
	/// <param name="caster">caster of the spell</param>
	/// <param name="target">target of the spell</param>
	protected virtual void CreatePrefab(GameObject caster, GameObject target)
	{
		Object prefab = Resources.Load(Prefab);
		if (prefab != null)
		{
			GameObject obj = GameObject.Instantiate(prefab, caster.transform.position, Quaternion.identity) as GameObject;
			SpellPrefab spellPrefab = obj.GetComponent<SpellPrefab>();
			if(spellPrefab != null)
			{
				spellPrefab.Name = Name;
				spellPrefab.AuraTexture = AuraTexture;
				spellPrefab.Value = Value;
				spellPrefab.Duration = Duration;
				spellPrefab.TickTimer = TickTimer;
				spellPrefab.StartTickingAtAuraApplication = StartTickingAtAuraApplication;
				spellPrefab.Effects = Effects;
				spellPrefab.Caster = caster;
				spellPrefab.Target = target;
			}
		}
	}
}
