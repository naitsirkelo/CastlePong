using UnityEngine;

public class CameraFollowYAxis : MonoBehaviour {

    public Transform target;

    public float midPos = 11.475f;
    public float offsetY = -1.4f;
    public float smoothSpeed = 0.125f;

    void FixedUpdate() {

        Vector3 desiredPosition = target.position + new Vector3(0, offsetY, -1);
        desiredPosition.x = midPos;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
