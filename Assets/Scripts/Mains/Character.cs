using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
	public string Name;
	public int Health;
	public GameObject Target;
	public List<Spell> SpellBook = new List<Spell>();
}
