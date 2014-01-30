public interface ISpell
{
    /// <summary>
    /// Name of the spell
    /// </summary>
    IName Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    int Cost { get; set; }
    /// <summary>
    /// ReesourceType used by the spell
    /// </summary>
    RessourceType RessourceType { get; set; }
    /// <summary>
    /// Range of the spell
    /// </summary>
    int Range { get; set; }
    /// <summary>
    /// CastTime of the spell
    /// </summary>
    int CastTime { get; set; }
    /// <summary>
    /// Duration of the spell
    /// </summary>
    int Duration { get; set; }
    /// <summary>
    /// Cooldown time of the spell
    /// </summary>
    float Cooldoown { get; set; }
    /// <summary>
    /// GlobalCooldown time of the spell
    /// </summary>
    float GlobalCooldown { get; set; }
    /// <summary>
    /// SchoolType of the spell
    /// </summary>
    SchoolType SchoolType { get; set; }
    /// <summary>
    /// MechanicType of the spell
    /// </summary>
    MechanicType MechanicType { get; set; }
    /// <summary>
    /// DispellType of the spell
    /// </summary>
    DispellType DispellType { get; set; }
    /// <summary>
    /// List of all effects to do by the spell
    /// </summary>
    IEffect[] Effects { get; set; }
    
    #region Flags
    /// <summary>
    /// The spell cannot be used while shapeshifted
    /// </summary>
    bool CannotUseWhileShapShift { get; set; }
    /// <summary>
    /// The spell connot be used while in combat
    /// </summary>
    bool CannotUseInCombat { get; set; }
    /// <summary>
    /// The spell is a passive spell
    /// </summary>
    bool PassiveSpell { get; set; }
    /// <summary>
    /// Hide the the spell aura
    /// </summary>
    bool HideAura { get; set; }
    /// <summary>
    /// The ticks start when the aura is applied
    /// </summary>
    bool StartTickAtAuraApplication { get; set; }
    #endregion
}
