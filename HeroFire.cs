using UnityEngine;

public class HeroFire : MonoBehaviour
{
    [Header("Параметры огня")]
    public float heatRate = 15f;
    public float coolingRate = 8f;
    public float maxTemperature = 100f;
    [Range(0f, 100f)]
    public float currentTemp = 0f;

    [Header("Визуальные эффекты")]
    public ParticleSystem fireParticles;
    public Light fireLight;
    public Color fireColor = new Color(1f, 0.5f, 0.1f);

    private bool isBurning = false;

    public float Temperature => currentTemp;

    public void Ignite()
    {
        isBurning = true;
        if (fireParticles) fireParticles.Play();
        if (fireLight) fireLight.enabled = true;
    }

    public void Extinguish()
    {
        isBurning = false;
        if (fireParticles) fireParticles.Stop();
        if (fireLight) fireLight.enabled = false;
    }

    private void Update()
    {
        if (isBurning && currentTemp < maxTemperature)
        {
            currentTemp += heatRate * Time.deltaTime;
        }
        else if (!isBurning && currentTemp > 0)
        {
            currentTemp -= coolingRate * Time.deltaTime;
        }

        currentTemp = Mathf.Clamp(currentTemp, 0f, maxTemperature);
    }
}