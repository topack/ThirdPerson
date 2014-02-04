using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DisplaySpellAuras : MonoBehaviour
{
	public Vector2 NumberOfAura;
	public Vector2 IconSize;

	public Character Character;
	public List<AuraIcon> Auras = new List<AuraIcon>();

	public void Awake()
	{
		Character = this.gameObject.GetComponent<Character>();
		Character.OnAuraAdded += AddAura;
		Character.OnAuraRemoved += RemoveAura;
	}

	public void Update()
	{
	}

	public void AddAura(SpellPrefab spellPrefab)
	{
		Object prefab = Resources.Load("Prefabs/Gui/IconAura");
		if (prefab != null)
		{
			GameObject iconSpellObj = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
			IconAura iconAura = iconSpellObj.GetComponent<IconAura>();
			iconAura.SetSpellPrefab(spellPrefab);
			iconAura.SetIconSize(IconSize);
			iconAura.Position = AuraPosition(Auras.Count());
			iconAura.Transform = this.transform;
			Auras.Add(new AuraIcon(iconAura, iconSpellObj));
			Debug.Log(spellPrefab.Name + " added to display icon");
		}
	}

	public void RemoveAura(SpellPrefab spellPrefab)
	{
		//TODO : remove instance of IconSpell GameObject
		GameObject.Destroy(Auras.Find(p => p.iconAura.SpellPrefab == spellPrefab).gameObject);
		Auras.RemoveAll(p => p.iconAura.SpellPrefab == spellPrefab);

		UpdateAuraPosition();

		Debug.Log(spellPrefab.Name + " removed from display icon");
	}

	private Vector2 AuraPosition(int nbAura)
	{
		float x = 0;
		float y = 0;

		int nbRow = Mathf.FloorToInt(nbAura / NumberOfAura.x);
		float auraInRow = nbAura - (nbRow * NumberOfAura.x);

		y = IconSize.y * nbRow;
		x = auraInRow * IconSize.x;

		return new Vector2(x, y);
	}

	private void UpdateAuraPosition()
	{
		int i = 0;
		foreach(AuraIcon auraIcon in Auras)
		{
			auraIcon.iconAura.Position = AuraPosition(i);
			i++;
		}
	}

	public class AuraIcon
	{
		public AuraIcon(IconAura ia, GameObject go)
		{
			iconAura = ia;
			gameObject = go;
		}
		
		public IconAura iconAura;
		public GameObject gameObject;
	}
}
