using UnityEngine;
using System.Collections.Generic;

public class SpellAoe : MonoBehaviour
{
	public SpellPrefab SpellPrefab;
	
	void Awake()
	{
		SpellPrefab = this.GetComponent<SpellPrefab>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		SpellPrefab.AoeTrigger(other.gameObject);
	}
}
