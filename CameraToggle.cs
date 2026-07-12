using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera camera1;
	public Camera camera2;
	
	// выбор начальной камеры
	private void Start()
	{
		camera1.gameObject.SetActive(true);
		camera2.gameObject.SetActive(false);
	}
	
	// переключение между камерами
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			camera1.gameObject.SetActive(!camera1.gameObject.activeSelf);
			camera2.gameObject.SetActive(!camera2.gameObject.activeSelf);
		}
	}
}
