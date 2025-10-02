using UnityEngine;

public class FlyCamMarker : MonoBehaviour
{
    public Camera spectatorCamera;
    public GameObject markerPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = spectatorCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Instancier un marqueur à l’endroit cliqué
                Instantiate(markerPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
