using UnityEngine;

public class HeroController : MonoBehaviour
{
    public HeroFire fire;
	public HeroWater water;
    public HeroDoor leftDoor;
    public HeroDoor rightDoor;

    private void Update()
    {
        // Управление огнём и потоком воды
        if (Input.GetKeyDown(KeyCode.F))
		{
            fire.Ignite();
			water.TurnOnWater();
		}
		
        if (Input.GetKeyDown(KeyCode.G))
		{
            fire.Extinguish();
			water.TurnOffWater();
		}
		
        // Открытие дверей
        float openPercent = fire.Temperature / fire.maxTemperature;

        if (leftDoor) leftDoor.SetOpenPercent(openPercent);
        if (rightDoor) rightDoor.SetOpenPercent(openPercent);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 100));
        // GUILayout.Label($"Температура: {fire.currentTemp:F1}°C");
        GUILayout.Label("F — Зажечь огонь");
        GUILayout.Label("G — Потушить огонь");
		GUILayout.Label("C — сменить камеру");
        GUILayout.EndArea();
    }
}
