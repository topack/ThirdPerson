using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
	public string Name;
	public int Health;
	public GameObject Target;
	public List<Spell> SpellBook = new List<Spell>();
	public List<SpellPrefab> Auras = new List<SpellPrefab>();

	public delegate void AuraAction(SpellPrefab spellPrefab);
	public event AuraAction OnAuraAdded;
	public event AuraAction OnAuraRemoved;

	public void FixedUpdate()
	{
		FixedUpdateLogic();
	}

	public virtual void FixedUpdateLogic()
	{
	}

	public virtual void AddAura(SpellPrefab spellPrefab)
	{
		if(spellPrefab != null)
		{
			Auras.Add(spellPrefab);

			if (OnAuraAdded != null)
			{
				OnAuraAdded(spellPrefab);
			}
		}
	}
	
	public virtual void RemoveAura(SpellPrefab spellPrefab)
	{
		if(spellPrefab != null)
		{
			Auras.Remove(spellPrefab);

			if (OnAuraRemoved != null)
			{
				OnAuraRemoved(spellPrefab);
			}
		}
	}
}
