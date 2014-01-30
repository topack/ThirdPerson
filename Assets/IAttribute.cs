using UnityEngine;
using System.Collections;

public class IAttribute : MonoBehaviour
{
    string Name { get; set;};
    float Value { get; set;};
    float MaximumValue { get; set;};
    
    void Add();
    void UpdateValue();
}
