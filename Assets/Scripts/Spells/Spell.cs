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
	public float Range;			// (0==self)
	public float CastTime;		// (instant == 0, channel < 0, cast > 0)
	public float Duration;
	public float TickTimer;
	public float Cooldown;
	public float GlobalCooldown;
	public SchoolType School;
	public MechanicType Mechanic;
	public DispellType DispellType;
	public bool CannotBeUsedInCombat;
	public bool CannotBeUsedWhileShapeshifted;
	public bool PassiveSpell;
	public bool SelfSpell;
	public bool HideAura;
	public bool StartTickingAtAuraApplication;
	public List<Spell> Effects = new List<Spell>();

	public float CooldownTimer;
	public bool IsEffect = false;
	#endregion

	void FixedUpdate()
	{
		Debug.Log("a");
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

		if(SelfSpell && caster != target)
		{
			Debug.Log("Self spell");
			return;
		}

		if (!IsEffect && Main.GlobalCoolDownTimer > 0)
		{
			Debug.Log("Globalcooldown not finished : " + Main.GlobalCoolDownTimer.ToString());
			return;
		}

		if(CooldownTimer > 0)
		{
			Debug.Log("Cooldown not finished : " + CooldownTimer.ToString());
			return;
		}

		if(!IsEffect && Vector3.Distance(caster.transform.position, target.transform.position) > Range)
		{
			Debug.Log("Out of range");
			return;
		}

		Debug.Log(string.Format("Cast spell : {0}", Name));
		if(!IsEffect)
		{
			Main.GlobalCoolDownTimer = GlobalCooldown;
			this.CooldownTimer = Cooldown;
		}

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
				spellPrefab.Spell = this;
				spellPrefab.Id = Id;
				spellPrefab.Name = Name;
				spellPrefab.AuraTexture = AuraTexture;
				spellPrefab.Value = Value;
				spellPrefab.Duration = Duration;
				spellPrefab.TickTimer = TickTimer;
				spellPrefab.StartTickingAtAuraApplication = StartTickingAtAuraApplication;
				spellPrefab.Effects = Effects;
				spellPrefab.Caster = caster;
				spellPrefab.Target = target;
				spellPrefab.Cooldown = Cooldown;
				spellPrefab.CooldownTimer = Cooldown;
				spellPrefab.Range = Range;
			}
		}
	}
}
