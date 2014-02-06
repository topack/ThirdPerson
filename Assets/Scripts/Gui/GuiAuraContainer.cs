using UnityEngine;
using System.Collections.Generic;

public class GuiAuraContainer : MonoBehaviour
{
	/// <summary>
	/// Number of aura to display horizontaly and verticaly.
	/// </summary>
	public Vector2 NumberOfAura;
	/// <summary>
	/// Size of the texture for the aura.
	/// </summary>
	public Vector2 AuraSize;
	/// <summary>
	/// If true the container will follow its transform for 3d render (exemple character plate).
	/// </summary>
	public bool FollowTransform;
	/// <summary>
	/// Position on screen When not following the its transform.
	/// </summary>
	public Vector2 PositionOnScreen;
	/// <summary>
	/// Display the auras of this Character.
	/// </summary>
	public Character character;

	private List<AuraInContainer> aurasInContainer = new List<AuraInContainer>();

	public void Awake()
	{
		character.OnAuraAdded += AddAura;
		character.OnAuraRemoved += RemoveAura;
	}

	public void FixedUpdate()
	{
		UpdateAuras();
	}

	public void AddAura(SpellPrefab spellPrefab)
	{
		if (aurasInContainer.Count >= (NumberOfAura.x * NumberOfAura.y))
		{
			return;
		}

		Object prefabGuiAura = Resources.Load(Main.PrefabGuiAura);
		if (prefabGuiAura != null)
		{
			GameObject iconObj = GameObject.Instantiate(prefabGuiAura, Vector3.zero, Quaternion.identity) as GameObject;
			iconObj.transform.parent = this.transform;
			GuiAura guiAura = iconObj.GetComponent<GuiAura>();
			aurasInContainer.Add(new AuraInContainer(guiAura, spellPrefab));
		}
	}

	public void RemoveAura(SpellPrefab spellPrefab)
	{
		GameObject.Destroy(aurasInContainer.Find(p => p.SpellPrefab == spellPrefab).GuiAura.gameObject);
		aurasInContainer.RemoveAll(p => p.SpellPrefab == spellPrefab);
	}

	#region private
	private void UpdateAuras()
	{
		Vector2 aurasContainerPosition = PositionOnScreen;
		if (FollowTransform)
		{
			aurasContainerPosition = Camera.main.WorldToScreenPoint(this.transform.position);
		}

		int nbAura = 0;
		foreach (AuraInContainer auraInContainer in aurasInContainer)
		{
			auraInContainer.GuiAura.UpdateGuiAura(
				aurasContainerPosition + AuraPosition(nbAura),
				AuraSize,
				auraInContainer.SpellPrefab.IconTexture,
				Mathf.CeilToInt(auraInContainer.SpellPrefab.Duration - auraInContainer.SpellPrefab.TotalDuration).ToString()
				);

			nbAura++;
		}
	}

	private Vector2 AuraPosition(int nbAura)
	{
		int nbRow = Mathf.FloorToInt(nbAura / NumberOfAura.x);
		float auraInRow = nbAura - (nbRow * NumberOfAura.x);

		return new Vector2(AuraSize.y * nbRow, auraInRow * AuraSize.x);
	}
	#endregion

	public class AuraInContainer
	{
		public AuraInContainer(GuiAura ia, SpellPrefab sp)
		{
			GuiAura = ia;
			SpellPrefab = sp;
		}

		public GuiAura GuiAura;
		public SpellPrefab SpellPrefab;
	}
}
