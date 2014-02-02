using UnityEngine;
using System.Collections.Generic;

public class GroundAoe : MonoBehaviour
{
	public Spell Spell;
	public Vector3 Position;
	public int Speed;
	public int Radius;

	public delegate void TriggerAction(GameObject gameObject);
	public static event TriggerAction OnTriggered;

	void Start()
	{
		Position = this.transform.position;
	}

	void FixedUpdate()
	{
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("GrouneAoe trigger");
		if(OnTriggered != null)
		{
			OnTriggered(other.gameObject);
		}
	}
}
