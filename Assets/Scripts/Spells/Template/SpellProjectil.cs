using UnityEngine;
using System.Collections;

public class SpellProjectil : MonoBehaviour
{
	/// <summary>
	/// Speed of the projectil in meter/second
	/// </summary>
	public int Speed;
	
	private SpellPrefab spellPrefab;
	
	public void Awake()
	{
		// get the SpellPrefab component on the GameObject
		spellPrefab = this.GetComponent<SpellPrefab>();
	}

	public void FixedUpdate()
	{
		// Move the projectil to the target
		transform.position = Vector3.MoveTowards(spellPrefab.transform.position, spellPrefab.Target.transform.position, Speed * Time.deltaTime);
	}

	public void OnTriggerEnter(Collider other)
	{
		// projectil enter a trigger
		spellPrefab.ProjectilTrigger(other.gameObject);
	}
}
