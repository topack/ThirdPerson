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
			totalTick = (int)(Duration / TickTimer);
		}
		
		ApplyAura(Target.GetComponent<Character>());
		StartCoroutine(MyCoroutine());
	}

	public override void FixedUpdateLogic()
	{
		if(nbTick == totalTick)
		{
			RemoveAura(Target.GetComponent<Character>());
			DestroySpellPrefab();
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
			Target.GetComponent<Character>().Health -= Value;

			yield return new WaitForSeconds(TickTimer);
		}
	}
}

