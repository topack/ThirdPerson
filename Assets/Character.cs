using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    #region Unity
    // called once when the script is attached to the object
    void Awake ()
    }
    }
  
    // called once when the script is enabled
    void Start()
    {
    }
  
    // called at fixed intervals
    void FixedUpdate ()
    {
    }
    
    // called every frame
    void Update ()
    {
    }
    #enregion
    
    Name Name;
    Level Level;
    Faction Faction;
    Attribute[] Attributes;
    Spell[] Spells;
    Aura[] Auras;
    Reputation[] Reputations;
}
