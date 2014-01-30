using UnityEngine;
using System.Collections.Generic;


public class Spell : MonoBehaviour
{
	public string Name;
	public int Range;		// (0==self)
	public int CastTime;	// (instant == 0, channel < 0, cast > 0)
	public int Duration;
	public int Cooldown;
	public int GlobalCooldown;
	public SchoolType School;
	public MechanicType Mechanic;
	public DispellType DispellType;
	public List<GameObject> Effects;
	public bool CannotBeUsedInCombat;
	public bool CannotBeUsedWhileShapeshifted;
	public bool PassiveSpell;
	public bool AuraIsHidden;
	public bool StartTickingAtAuraApplication;

	private List<Spell> SpellEffects = new List<Spell>();

	void Awake()
	{
		foreach(GameObject go in Effects)
		{
			Spell spell = go.GetComponent<Spell>();
			SpellEffects.Add(spell);
		}
	}

	/// <summary>
	/// Casts the spell on the target
	/// </summary>
	/// <param name="Target">Target of the spell</param>
	public virtual void CastSpell(GameObject Target)
	{
		ApplyEffects(Target);
	}

	/// <summary>
	/// Applies the effects of the spell
	/// </summary>
	/// <param name="Target">Target of the spell</param>
	protected void ApplyEffects(GameObject target)
	{
		foreach(Spell spell in SpellEffects)
		{
			spell.CastSpell(target);
		}
	}
}