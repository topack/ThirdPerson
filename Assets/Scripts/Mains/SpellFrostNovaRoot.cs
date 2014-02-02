using UnityEngine;
using System.Collections;

public class SpellFrostNovaRoot : SpellNova
{
	public override void Trigger(GameObject gameobject)
	{
		Character target = gameobject.GetComponent<Character>();
		if(target != null)
		{
			Debug.Log ("Root");
		}
	}
}
