using UnityEngine;
using System.Collections.Generic;

public class GuiAuras : MonoBehaviour
{
	public Vector2 NumberOfAura;
	public Vector2 IconSize;
	
	private List<AuraIcon> auraIcons = new List<AuraIcon>();
	public Character character;

	public void Awake()
	{
		character.OnAuraAdded += AddAura;
		character.OnAuraRemoved += RemoveAura;
	}

	public void FixedUpdate()
	{
		UpdateText();
	}

	public void AddAura(SpellPrefab spellPrefab)
	{
		Object prefabGuiAura = Resources.Load(Main.PrefabGuiAura);
		if (prefabGuiAura != null)
		{
			GameObject iconObj = GameObject.Instantiate(prefabGuiAura, Vector3.zero, Quaternion.identity) as GameObject;
			iconObj.transform.parent = this.transform;
			GuiAura guiAura = iconObj.GetComponent<GuiAura>();
			guiAura.Init(IconSize, AuraPosition(auraIcons.Count), this.transform, spellPrefab.IconTexture);

			auraIcons.Add(new AuraIcon(guiAura, spellPrefab));
		}
	}

	public void RemoveAura(SpellPrefab spellPrefab)
	{
		GameObject.Destroy(auraIcons.Find(p => p.SpellPrefab == spellPrefab).GuiAura.gameObject);
		auraIcons.RemoveAll(p => p.SpellPrefab == spellPrefab);

		UpdateAuraPosition();
	}

	#region private
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
		foreach (AuraIcon auraIcon in auraIcons)
		{
			auraIcon.GuiAura.UpdatePositionOffset(AuraPosition(i));
			i++;
		}
	}

	private void UpdateText()
	{
		foreach (AuraIcon auraIcon in auraIcons)
		{
			auraIcon.GuiAura.UpdateText(Mathf.CeilToInt(auraIcon.SpellPrefab.Duration - auraIcon.SpellPrefab.TotalDuration).ToString());
		}
	}
	#endregion

	public class AuraIcon
	{
		public AuraIcon(GuiAura ia, SpellPrefab sp)
		{
			GuiAura = ia;
			SpellPrefab = sp;
		}
		
		public GuiAura GuiAura;
		public SpellPrefab SpellPrefab;
	}
}
