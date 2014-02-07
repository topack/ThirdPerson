using UnityEngine;
using System.Collections.Generic;

public class Spell : MonoBehaviour
{
	#region Declaration
	public int Id;
	public string Name;
	public Texture AuraTexture;
	public int Value;
	public int Range;
	public int CastTime;
	public int Duration;
	public int TickTimer;
	public int Cooldown;
	public float CooldownTimer;
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
	public Character Character;
	#endregion

	/// <summary>
	/// Casts the spell on the target
	/// </summary>
	public virtual void Cast(Character target)
	{
		if(target == null)
		{
			Debug.Log("No target selected");
			return;
		}

		if (Main.GlobalCoolDownTimer >= 0)
		{
			Debug.Log("Globalcooldown : " + Main.GlobalCoolDownTimer.ToString());
			return;
		}

		Debug.Log(string.Format("Cast spell : {0}", Name));

		Main.GlobalCoolDownTimer = GlobalCooldown;
		this.CooldownTimer = Cooldown;

		CreatePrefab(target);
	}

	/// <summary>
	/// Create the prefab of the spell
	/// </summary>
	/// <param name="caster">caster of the spell</param>
	/// <param name="target">target of the spell</param>
	protected virtual void CreatePrefab(Character target)
	{
		GameObject obj = GameObject.Instantiate(this.gameObject, caster.transform.position, Quaternion.identity) as GameObject;
		obj.GetComponent<Spell>().SetTarget(target);
	}

	public void SetTarget(Character target)
	{

	}

	/// <summary>
	/// Applly all the effects of the spell
	/// </summary>
	public virtual void ApplyEffects()
	{
		// foreach effects cast the spell
		foreach (Spell spell in Effects)
		{
			spell.Cast(Target);
		}
	}

	/// <summary>
	/// Add the aura of the spell on the target
	/// </summary>
	/// <param name="target"></param>
	public virtual void ApplyAura(Character target)
	{
		if (target != null)
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
		if (target != null)
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
	public virtual void AoeTrigger(GameObject gameObject)
	{
		Debug.Log("SpellPrefab AoeTrigger");
	}
}
