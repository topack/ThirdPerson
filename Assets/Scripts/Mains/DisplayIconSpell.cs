using UnityEngine;
using System.Collections;

public class DisplayIconSpell : MonoBehaviour
{
        public Vector2 Position;
        public Vector2 Size;
        public Character Character;
        
        private List<IconSpell> IconSpell = new List<IconSpell>();
        
        /// <TODO>
        /// subscribe event Character.AddAura()
        /// subscribe event Character.RemoveAura()
        /// </TODO>
        
        void OnAwake()
        {
                Character.OnAuraAdded += DisplayIcon();
        }
        
        public void DisplayIcon(SpellPrefab spellPrefab)
        {
                
        }
}
