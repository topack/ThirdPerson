using UnityEngine;
using System.Collections;

public class SpellDot : MonoBehaviour
{
	public SpellPrefab SpellPrefab;
	
	void Awake()
	{
		SpellPrefab = this.GetComponent<SpellPrefab>();
	}
}
