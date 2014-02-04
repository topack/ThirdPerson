using UnityEngine;
using System.Collections;

public class SpellProjectil : MonoBehaviour
{
	public SpellPrefab SpellPrefab;

	void Awake()
	{
		SpellPrefab = this.GetComponent<SpellPrefab>();
	}

	void OnTriggerEnter(Collider other)
	{
		SpellPrefab.ProjectilTrigger(other.gameObject);
	}
}
