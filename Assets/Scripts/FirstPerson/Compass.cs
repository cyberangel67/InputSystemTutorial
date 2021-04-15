using UnityEngine.UI;
using UnityEngine;

using TMPro;

public class Compass : MonoBehaviour
{
	[SerializeField] private RawImage CompassImage;
	[SerializeField] private Transform Player;
	[SerializeField] private TMP_Text CompassDirectionText;

	public void Update()
	{
		CompassImage.uvRect = new Rect(Player.localEulerAngles.y / 360, 0, 1, 1);

		Vector3 forward = Player.transform.forward;
		forward.y = 0;

		float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
		headingAngle = 1 * (Mathf.RoundToInt(headingAngle / 1.0f));

		int displayangle;
		displayangle = Mathf.RoundToInt(headingAngle);

		CompassDirectionText.text = displayangle switch { 
		
			0 => "N",
			360 => "N",
			45 => "NE",
			90 => "E",
			135 => "SE",
			180 => "S",
			225 => "SW",
			270 => "W",
			315 => "NW",
			_ => headingAngle.ToString()
		};
	}

}