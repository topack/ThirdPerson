using UnityEngine;
using System.Collections.Generic;

public class SpellPrefab : MonoBehaviour
{
	public int Id;
	public string Name;
	public Texture IconTexture;
	public int Value;
	public int Range;		// (0==self)
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

	public GameObject Caster;
	public GameObject Target;
	public float TotalDuration;
	
	public virtual void ApplyEffects()
	{
		foreach(Spell spell in Effects)
		{
			spell.Cast(Caster, Target);
		}
	}

	public virtual void ApplyAura(Character target)
	{
		if(target != null)
		{
			target.Auras.Add(this);
		}
	}
	
	public virtual void ProjectilTrigger(GameObject gameobject)
	{
		Debug.Log("SpellPrefab ProjectilTrigger");
	}

	public virtual void AoeTrigger (GameObject gameObject)
	{
		Debug.Log("SpellPrefab AoeTrigger");
	}
}
