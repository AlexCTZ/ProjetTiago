using UnityEngine;

public class FlyCamMarker : MonoBehaviour
{
    public Camera spectatorCamera;
    public GameObject markerPrefab;

    private GameObject currentMarker;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = spectatorCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (currentMarker != null)
                {
                    Destroy(currentMarker);
                }

                // Instancier un nouveau marqueur à l’endroit cliqué
                currentMarker = Instantiate(markerPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
