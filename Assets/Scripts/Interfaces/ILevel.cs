public interface ILevel
{
    ///<summary>
    /// Current level
    ///</summary>
    int value { get; set; }
    ///<summary>
    /// Maximum Level
    ///</summary>
    int MaximumValue { get; set; }
    ///<summary>
    /// Current experience for the level
    ///</summary>
    int Experience { get; set; }
    ///<summary>
    /// Experience needed to level up
    ///</summary>
    int ExperienceForNextLevel { get; set; }
}
