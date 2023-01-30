using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            var explosion = Instantiate(explosionPrefab, mousePosition, Quaternion.identity);
            Destroy(explosion, 1f);
        }   
    }
}
