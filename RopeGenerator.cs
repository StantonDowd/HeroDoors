using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    public GameObject ropeSegmentPrefab;
    public Transform startPoint;      // точка от ведра
    public Transform endPoint;        // точка на двери
    public int segmentCount = 12;
    public float segmentLength = 0.3f;

    private GameObject[] segments;

    void Start()
    {
        GenerateRope();
    }

    public void GenerateRope()
    {
        if (segments != null)
        {
            foreach (var s in segments) Destroy(s);
        }

        segments = new GameObject[segmentCount];
        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        Vector3 currentPos = startPoint.position;

        for (int i = 0; i < segmentCount; i++)
        {
            segments[i] = Instantiate(ropeSegmentPrefab, currentPos, Quaternion.identity, transform);
            Rigidbody rb = segments[i].GetComponent<Rigidbody>();

            HingeJoint joint = segments[i].GetComponent<HingeJoint>();
            joint.axis = new Vector3(1, 0, 0); // или подкорректируй

            if (i > 0)
            {
                joint.connectedBody = segments[i - 1].GetComponent<Rigidbody>();
                joint.anchor = new Vector3(0, -0.5f, 0); // нижний конец сегмента
            }
            else
            {
                // Первый сегмент крепится к ведру
                joint.connectedBody = startPoint.GetComponent<Rigidbody>();
            }

            currentPos += direction * segmentLength;
        }

        // Последний сегмент к двери
        HingeJoint lastJoint = segments[segmentCount - 1].GetComponent<HingeJoint>();
        lastJoint.connectedBody = endPoint.GetComponent<Rigidbody>();
    }
}
