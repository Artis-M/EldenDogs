using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Player playerHealth;
	public Image fillImage;
	private Slider slider;
	private float maxHealth = 10;
	void Awake()
	{
		slider = GetComponent<Slider>();
	}

	
	void Update() {
		if (slider.value <= slider.minValue)
		{
			fillImage.enabled = false;
		}

		if (slider.value > slider.minValue && !fillImage.enabled)
		{
			fillImage.enabled = true;
		}

		float fillValue = playerHealth.health / maxHealth;
		if (fillValue <= slider.maxValue / 3)
		{
			fillImage.color = Color.white;
		}
		else if (fillValue > slider.maxValue / 3)
		{
			fillImage.color = Color.red;
		}

		slider.value = fillValue;
	}
}