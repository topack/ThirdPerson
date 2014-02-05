using UnityEngine;

[RequireComponent(typeof(GUIText))]
public class GuiLabel : MonoBehaviour
{
	private Vector2 positionOffset;
	private Vector3 screenPos;
	private Transform transformToFollow;
	private GUIText guiLabel;

	public void Awake()
	{
		guiLabel = this.gameObject.GetComponent<GUIText>();
	}

	public void Init(Vector2 size, Vector2 positionOffset, Transform transformToFollow, string text)
	{
		this.positionOffset = positionOffset;
		this.transformToFollow = transformToFollow;
		this.guiLabel.text = text;
	}

	public void FixedUpdate()
	{
		if (transformToFollow != null)
		{
			screenPos = Camera.main.WorldToScreenPoint(transformToFollow.position);
		}
		else
		{
			screenPos = Vector3.zero;
		}
		guiLabel.pixelOffset = new Vector2(screenPos.x + positionOffset.x, screenPos.y + positionOffset.y);
	}

	public void UpdateText(string text)
	{
		guiLabel.text = text;
	}
}
