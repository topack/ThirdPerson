public interface IAttribute
{
    /// <summary>
    /// Name of the attribute
    /// </summary>
    IName Name { get; set; };
    /// <summary>
    /// Value of the attribute
    /// </summary>
    float Value { get; set; };
    /// <summary>
    /// Maximum value of the attribute
    /// </summary>
    float MaximumValue { get; set; };
    
    /// <summary>
    /// add the value to the attribute value
    /// </summary>
    void Add(int value);
    /// <summary>
    /// add the value to the attribute maximum value
    /// </summary>
    void AddMaximum(int value);
    /// <summary>
    /// Update the values of the attribute
    /// </summary>
    void UpdateValues();
}
