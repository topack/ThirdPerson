public interface ICharacter
{
    /// <summary>
    /// Name of the character
    /// </summary>
    IName Name { get; set; }
    /// <summary>
    /// Level of the character
    /// </summary>
    ILevel { get; set; }
    /// <summary>
    /// Faction of the character
    /// </summary>
    FactionType Faction { get; set; }
    /// <summary>
    /// Attribute list of the character
    /// </summary>
    IAttribute[] Attributes { get; set; }
    /// <summary>
    /// Spell List of the character
    /// </summary>
    ISpell[] Spells { get; set; }
    /// <summary>
    /// Aura List of the character
    /// </summary>
    ISpell[] Auras { get; set; }
    /// <summary>
    /// Reputation list of the character
    /// </summary>
    IReputation[] Reputations { get; set; }
    
    #region Unity
    /// <summary>
    /// called once when the script is attached to the object
    /// </summary>
    void Awake ();
    
    /// <summary>
    /// called once when the script is enabled
    /// </summary>
    void Start();
    
    /// <summary>
    /// called at fixed intervals
    /// </summary>
    void FixedUpdate ();
    
    /// <summary>
    /// called every frame
    /// </summary>
    void Update ();
    #enregion
}
