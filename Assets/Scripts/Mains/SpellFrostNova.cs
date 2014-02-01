using UnityEngine;
using System.Collections;

public class SpellFrostNova : Spell
{
	/// <summary>
	/// Apply the effect of the spell
	/// </summary>
	protected override void ApplySelf(GameObject caster, GameObject target)
	{
		Character character = target.GetComponent<Character>();
		if (character != null)
		{
			character.Health -= this.Value;
		}
	}
}
