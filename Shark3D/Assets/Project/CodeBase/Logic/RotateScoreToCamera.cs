using UnityEngine;

public class RotateScoreToCamera : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private Vector3 _positionToLook;
    private Transform _transformCamera;

    private void Start()
    {
        _transformCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (_transformCamera == null)
            return;

        RotateTowardsCamera();
    }

    private void RotateTowardsCamera()
    {
        Vector3 positionDiff = _transformCamera.position - transform.position;
        _positionToLook = new Vector3(positionDiff.x, transform.position.y, positionDiff.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_positionToLook)
            , _speedRotate * Time.deltaTime);
    }
}
