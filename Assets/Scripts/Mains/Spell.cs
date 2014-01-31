using UnityEngine;
using System.Collections.Generic;


public class Spell : MonoBehaviour
{
	#region Declaration
	public string Name;
	public Texture Texture;
	public int Range;	// (0==self)
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
	public List<Spell> Effects;
	#endregion

	public void Awake()
	{
	}

	/// <summary>
	/// Casts the spell on the target
	/// </summary>
	public virtual void Cast()
	{
		SelfEffect();
		ApplyEffects();
	}
	
	protected virtual void SelfEffect()
	{
		
	}
	
	/// <summary>
	/// Applies the effects of the spell
	/// </summary>
	protected virtual void ApplyEffects()
	{
		foreach(Spell spell in Effects)
		{
			spell.Cast();
		}
	}
}
