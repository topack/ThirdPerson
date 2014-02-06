using UnityEngine;
using System.Collections.Generic;

public class SpellAoe : MonoBehaviour
{
	private SpellPrefab spellPrefab;
	
	void Awake()
	{
		spellPrefab = this.GetComponent<SpellPrefab>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		spellPrefab.AoeTrigger(other.gameObject);
	}
}
