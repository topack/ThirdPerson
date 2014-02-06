using UnityEngine;
using System.Collections.Generic;

public class SpellPrefab : MonoBehaviour
{
	#region declaration
	/// <summary>
	/// Id of the spell
	/// </summary>
	public int Id;
	/// <summary>
	/// Name of the spell
	/// </summary>
	public string Name;
	/// <summary>
	/// Texture for the aura of the spell
	/// </summary>
	public Texture AuraTexture;
	/// <summary>
	/// Value of the spell
	/// </summary>
	public int Value;
	/// <summary>
	/// range of the spell (0 == self)
	/// </summary>
	public int Range;
	/// <summary>
	/// CastTime of the spell (instant == 0, channel < 0, cast > 0)
	/// </summary>
	public int CastTime;
	/// <summary>
	/// Duration of the spell (-1 permanent)
	/// </summary>
	public int Duration;
	/// <summary>
	/// Time between each tick of the spell
	/// </summary>
	public int TickTimer;
	/// <summary>
	/// Cooldown of the spell
	/// </summary>
	public int Cooldown;
	/// <summary>
	/// GlobalCooldown time
	/// </summary>
	public int GlobalCooldown;
	/// <summary>
	/// School type of the spell
	/// </summary>
	public SchoolType School;
	/// <summary>
	/// Mechanic type of the spell
	/// </summary>
	public MechanicType Mechanic;
	/// <summary>
	/// Dispell type of the spell
	/// </summary>
	public DispellType DispellType;
	/// <summary>
	/// spell CannotBeUsedInCombat
	/// </summary>
	public bool CannotBeUsedInCombat;
	/// <summary>
	/// spell CannotBeUsedWhileShapeshifted
	/// </summary>
	public bool CannotBeUsedWhileShapeshifted;
	/// <summary>
	/// spell is a PassiveSpell
	/// </summary>
	public bool PassiveSpell;
	/// <summary>
	/// hide the aura of the spell
	/// </summary>
	public bool HideAura;
	/// <summary>
	/// spell StartTickingAtAuraApplication
	/// </summary>
	public bool StartTickingAtAuraApplication;
	/// <summary>
	/// Effects applyed by the spell after its application
	/// </summary>
	public List<Spell> Effects = new List<Spell>();
	/// <summary>
	/// Caster of the spell
	/// </summary>
	public GameObject Caster;
	/// <summary>
	/// target of the spell
	/// </summary>
	public GameObject Target;
	/// <summary>
	/// TotalDuration done by the spell
	/// </summary>
	public float TotalDuration;
	#endregion

	/// <summary>
	/// Applly all the effects of the spell
	/// </summary>
	public virtual void ApplyEffects()
	{
		// foreach effects cast the spell
		foreach(Spell spell in Effects)
		{
			spell.Cast(Caster, Target);
		}
	}
	
	/// <summary>
	/// Add the aura of the spell on the target
	/// </summary>
	/// <param name="target"></param>
	public virtual void ApplyAura(Character target)
	{
		if(target != null)
		{
			target.AddAura(this);
		}
	}
	
	/// <summary>
	/// Remove the aura of the spell on the target
	/// </summary>
	/// <param name="target"></param>
	public virtual void RemoveAura(Character target)
	{
		if(target != null)
		{
			target.RemoveAura(this);
		}
	}
	
	/// <summary>
	/// Method when the pojectil enter a trigger
	/// </summary>
	/// <param name="gameobject">GameObject wich enter the trigger</param>
	public virtual void ProjectilTrigger(GameObject gameobject)
	{
		Debug.Log("SpellPrefab ProjectilTrigger");
	}

	/// <summary>
	/// Method when the aoe enter a trigger
	/// </summary>
	/// <param name="gameObject">GameObject wich enter the trigger</param>
	public virtual void AoeTrigger (GameObject gameObject)
	{
		Debug.Log("SpellPrefab AoeTrigger");
	}
}
