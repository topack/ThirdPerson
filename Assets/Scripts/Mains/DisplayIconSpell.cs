using UnityEngine;
using System.Collections;

public class DisplayIconSpell : MonoBehaviour
{
        public Vector2 Position;
        public Vector2 Size;
        
        private Character Character;
        
        void OnAwake()
        {
                Character = this.GameObject.GetComponent<Character>();
        }
        
        void OnGUI()
        {
                //TODO display 
                if(Character ! =null)
                {
                        foreach(SpellPrefab spellPrefab in Character.Auras)
                        {
                                
                        }
                }
        }
}
