using UnityEngine;

public class HeroDoor : MonoBehaviour
{
    [Header("Настройки двери")]
    public Transform pivot;           // Пустой объект — центр вращения
    public float openAngle = 110f;
    public float openSpeed = 90f;
    public float closeSpeed = 45f;

    private float targetAngle = 0f;
    private float currentAngle = 0f;

    public void SetOpenPercent(float percent) // 0.0 - 1.0
    {
        targetAngle = openAngle * Mathf.Clamp01(percent);
    }

    private void Update()
    {
        float speed = targetAngle > currentAngle ? openSpeed : closeSpeed;
        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, speed * Time.deltaTime);

        if (pivot != null)
            pivot.localRotation = Quaternion.Euler(0, currentAngle, 0);
        else
            transform.localRotation = Quaternion.Euler(0, currentAngle, 0);
    }
}
