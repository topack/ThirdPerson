using UnityEngine;
using System.Collections;

public class ICharacter : MonoBehaviour
{
    #region Unity
    // called once when the script is attached to the object
    void Awake ();
  
    // called once when the script is enabled
    void Start();
  
    // called at fixed intervals
    void FixedUpdate ();
    
    // called every frame
    void Update ();
    #enregion
    
    Name Name { get; set;};
    Level Level { get; set;};
    Faction Faction { get; set;};
    Attribute[] Attributes { get; set;};
    Spell[] Spells { get; set;};
    Aura[] Auras { get; set;};
    Reputation[] Reputations { get; set;};
}
