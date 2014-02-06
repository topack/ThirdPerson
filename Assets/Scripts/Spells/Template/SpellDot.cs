using UnityEngine;
using System.Collections;

public class SpellDot : MonoBehaviour
{
	public SpellPrefab spellPrefab;
	
	void Awake()
	{
		spellPrefab = this.GetComponent<SpellPrefab>();
	}
}
