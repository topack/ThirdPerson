using UnityEngine;
using System.Collections.Generic;


public class Spell
{
	#region Declaration
	public int Id;
	public string Name;
	public Texture IconTexture;
	public GameObject SpellObject;
	public int Range;		// (0==self)
	public int CastTime;	// (instant == 0, channel < 0, cast > 0)
	public int Duration;
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
	
	private GameObject Caster;
	private GameObject Target;
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

		Debug.Log(string.Format("{0} cast {1} on {2}", caster.GetComponent<Character>().Name, this.Name, target.GetComponent<Character>().Name));

		ApplyEffects(caster, target);
	}
	
	/// <summary>
	/// Applies the effects of the spell
	/// </summary>
	protected virtual void ApplyEffects(GameObject caster, GameObject target)
	{
		foreach(Spell spell in Effects)
		{
			spell.Cast(caster, target);
		}
	}
}
