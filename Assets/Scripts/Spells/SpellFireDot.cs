using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpellDot))]
public class SpellFireDot : SpellPrefab
{
	private int totalTick = 1;
	private int nbTick = 0;

	void Start()
	{
		if(TickTimer > 0)
		{
			totalTick = Duration / TickTimer;
		}
		
		ApplyAura(Target.GetComponent<Character>());
		StartCoroutine(MyCoroutine());
	}

	void FixedUpdate()
	{
		if(nbTick == totalTick)
		{
			RemoveAura(Target.GetComponent<Character>());
			Destroy(this.gameObject);
		}
		else
		{
			TotalDuration += Time.deltaTime;
		}
	}

	IEnumerator MyCoroutine ()
	{
		if(!StartTickingAtAuraApplication)
		{
			yield return new WaitForSeconds(TickTimer);
		}

		while(nbTick != totalTick)
		{
			nbTick++;

			Debug.Log("Dot " + nbTick  + " / " + totalTick);
			Target.GetComponent<Character>().Health -= Value;

			yield return new WaitForSeconds(TickTimer);
		}
	}
}

