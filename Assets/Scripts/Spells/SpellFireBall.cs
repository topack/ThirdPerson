using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpellProjectil))]
public class SpellFireBall : SpellPrefab
{
	/// <summary>
	/// Attached to a SpellProjectil trigger event
	/// </summary>
	/// <param name="gameobject">GameObject whos entered the trigger of the spell</param>
	public override void ProjectilTrigger(GameObject gameobject)
	{
		Character target = gameobject.GetComponent<Character>();
		if(target != null && target == Target.GetComponent<Character>())
		{
			// apply damage to the target
			target.Health -= Value;

			// apply the effects of the spells on the target
			ApplyEffects();

			// destroy the spell
			Destroy(this.gameObject);
		}
	}
}
