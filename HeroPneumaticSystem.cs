using UnityEngine;

public class HeroPneumaticSystem : MonoBehaviour
{
    public HeroFire fire;
	public HeroWater water;
    public Transform waterBucket;           // ведро с водой
	public Transform counterWeight;			// противовес
    public float maxBucketDrop = 2f;        // насколько опускается ведро
    public float maxCWUp = 2f;				// насколько поднимается противовес
	public float smoothTime = 0.5f;

    private float currentHeight;
	private float currentCWHeight;
    private float velocity;

    private void Start()
    {
        currentHeight = waterBucket.localPosition.y;
		currentCWHeight = counterWeight.localPosition.y;
    }

    private void Update()
    {
        // расчет новой позиции ведра
		float targetDrop = Mathf.Lerp(0, maxBucketDrop, fire.Temperature / fire.maxTemperature);
        float targetY = currentHeight - targetDrop;
		// расчет новой позиции противовеса
		float targetCWUp = Mathf.Lerp(0, maxCWUp, fire.Temperature / fire.maxTemperature);
		float targetCWY = currentCWHeight + targetCWUp;

        // меняем позицию ведра
		waterBucket.localPosition = new Vector3(
            waterBucket.localPosition.x,
            Mathf.SmoothDamp(waterBucket.localPosition.y, targetY, ref velocity, smoothTime),
            waterBucket.localPosition.z
        );
		
		// меняем позицию противовеса
/* 		counterWeight.localPosition = new Vector3(
            counterWeight.localPosition.x,
            Mathf.SmoothDamp(counterWeight.localPosition.y, targetY, ref velocity, smoothTime),
            counterWeight.localPosition.z
        ); */
		counterWeight.localPosition = new Vector3(
            counterWeight.localPosition.x,
            (-1 * Mathf.SmoothDamp(waterBucket.localPosition.y, targetY, ref velocity, smoothTime)),
            counterWeight.localPosition.z
        );
		
    }
}
