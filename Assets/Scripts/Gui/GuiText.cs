using UnityEngine;

[RequireComponent(typeof(GUIText))]
public class GuiText : MonoBehaviour
{
	private Vector2 Size;
	private Vector2 PositionOffset;
	private Vector3 screenPos;
	private Transform transformToFollow;
	private GUIText guiText;

	public void Awake()
	{
		guiText = this.gameObject.GetComponent<GUIText>();
	}

	public void Init(Vector2 size, Vector2 positionOffset, Transform transformToFollow, string text)
	{
		Size = size;
		PositionOffset = positionOffset;
		this.transformToFollow = transformToFollow;
		guiText.text = text;
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
		guiText.pixelOffset = new Vector2(screenPos.x + PositionOffset.x, screenPos.y + PositionOffset.y);
	}

	public void UpdateText(string text)
	{
		guiText.text = text;
	}
}
