using UnityEngine;

public class Scripts_Parallax : MonoBehaviour
{
    [SerializeField] Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 prevCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        prevCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - prevCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, transform.position.z);
        prevCameraPosition = cameraTransform.position;
    }
}
