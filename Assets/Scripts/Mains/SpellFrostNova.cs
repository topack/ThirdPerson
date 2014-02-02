using UnityEngine;
using System.Collections;

public class SpellFrostNova : SpellNova
{
	public override void Trigger(GameObject gameobject)
	{
		Debug.Log("Frostnova groundAoe : " + gameobject.name);
		Character target = gameobject.GetComponent<Character>();
		if(target != null && target != Main.Player)
		{
			Debug.Log(string.Format("{0} cast {1} on {2} for {3}", Main.Player.Name, this.Name, target.Name, Value.ToString()));
			target.Health -= Value;
		}
	}
}
