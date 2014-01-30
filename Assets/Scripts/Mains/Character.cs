using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, ICharacter
{
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
    #endregion
}
