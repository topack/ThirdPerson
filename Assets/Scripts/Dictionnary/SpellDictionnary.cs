using UnityEngine;
using System.Collections.Generic;

public static class SpellDictionnary
{
	static Dictionary<int, string> iconTexture = new Dictionary<int, string>() {
		{1, "Icons/Spell_fire_fireball02"},
		{2, "Icons/Spell_frost_frostnova"}
	};

	public static string GetIconTexture(int spellId)
	{
		string result;
		if (iconTexture.TryGetValue(spellId, out result))
		{
			return result;
		}
		else
		{
			return null;
		}
	}
}

