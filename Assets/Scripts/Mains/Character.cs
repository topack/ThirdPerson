using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
	#region Declaration
	public int Health;
	public List<Spell> Spells
	
	public GameObject Target;
	#endregion
	
	public AddSpell(Spell spell)
	{
		if(spell != null)
		{
			Spells.Add(spell);
		}
	}
	
	public CastSpell(int spellId)
	{
		Spell cast = Spells.FirstOrDefault(p => p.SpellId == spellId);
		if(cast != null)
		{
			spell.Cast(this.GameObject, Target);
		}
	}
}
