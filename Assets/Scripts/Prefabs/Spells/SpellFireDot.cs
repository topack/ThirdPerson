using UnityEngine;
using System.Collections;

public class SpellFireDot : SpellPrefab
{
	public int TotalTick = 1;
	public int nbTick = 0;

	void Start()
	{
		if(TickTimer > 0)
		{
			TotalTick = Duration / TickTimer;
		}
		
		ApplyAura(Target.GetComponent<Character>());
		StartCoroutine(MyCoroutine());
	}

	void FixedUpdate()
	{
		if(nbTick == TotalTick)
		{
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

		while(nbTick != TotalTick)
		{
			nbTick++;

			Debug.Log("Dot " + nbTick  + " / " + TotalTick);
			Target.GetComponent<Character>().Health -= Value;

			yield return new WaitForSeconds(TickTimer);
		}
	}
}

