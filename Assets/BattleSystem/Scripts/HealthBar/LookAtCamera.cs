using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform _camera;

    private void Awake() 
    {
        _camera = UnityEngine.Camera.main.transform;
    }
    
    private void LateUpdate() 
    {
        transform.LookAt(transform.position + _camera.forward);    
    }
}
