using UnityEngine;
using System.Collections;

public class SpellNova : Spell
{
	protected override void ApplySelf(GameObject caster, GameObject target)
	{
		Object prefab = Resources.Load(Prefab);
		if(prefab != null)
		{
			GameObject obj = GameObject.Instantiate(prefab, caster.transform.position, Quaternion.identity) as GameObject;
			GroundAoe groundAoe = obj.GetComponent<GroundAoe>();
			if(groundAoe != null)
			{
				groundAoe.Spell = this;
				// register to event triggerEnter from GroundAoe
				GroundAoe.OnTriggered += Trigger;
			}
			else
			{
				Debug.LogError("Prefab don't have GroundAoe");
			}
		}
		else
		{
			Debug.LogError("Spell don't have prefab");
		}
	}

	public virtual void Trigger(GameObject gameobject)
	{
	}

	protected void OnDisable()
	{
		Debug.Log("Remove Event Trigger");
		GroundAoe.OnTriggered -= Trigger;
	}
}
