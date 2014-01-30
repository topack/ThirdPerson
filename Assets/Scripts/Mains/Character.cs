using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
	#region Declaration
	public int Value;
	public List<GameObject> Spells;
	#endregion
	
    #region Unity
    /// <summary>
    /// called once when the script is attached to the object
    /// </summary>
    void Awake ()
	{
		Spell spell = Spells[0].GetComponent<Spell>();
		spell.CastSpell(this.gameObject);
		Debug.Log(this.Value);
	}
    
    /// <summary>
    /// called once when the script is enabled
    /// </summary>
    void Start()
	{

	}
    
    /// <summary>
    /// called at fixed intervals
    /// </summary>
    void FixedUpdate ()
	{

	}
    
    /// <summary>
    /// called every frame
    /// </summary>
    void Update ()
	{

	}
    #endregion
}
