using UnityEngine;
using System.Collections;

public class SpellFireBall : SpellPrefab
{
	public override void ProjectilTrigger(GameObject gameobject)
	{
		Character target = gameobject.GetComponent<Character>();
		if(target != null && target == Target.GetComponent<Character>())
		{
			Debug.Log("SpellFireBall ProjectilTrigger");
			target.Health -= Value;

			ApplyEffects();
		}
	}
}

