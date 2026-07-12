using UnityEngine;

public class HeroWater : MonoBehaviour
{
    // частицы воды
	[Header("Визуальные эффекты воды")]
	public ParticleSystem waterParticles;
	public Color waterColor = new Color(0f, 0f, 1f);
	
//	private bool isLeaking = false;
	
	// открыть воду
	public void TurnOnWater()
    {
 //       isLeaking = true;
        if (waterParticles) waterParticles.Play();
    }
	
	// перекрыть воду
	public void TurnOffWater()
    {
//        isLeaking = false;
        if (waterParticles) waterParticles.Stop();
    }
	
	private void Update()
	{
		
	}

}
