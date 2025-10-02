using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //public Camera xrCamera;
    public Camera FlyCamera;

    private bool usingSpectator = false;

    void Start()
    {
        // Assure que les deux caméras sont actives
        //xrCamera.gameObject.SetActive(true);
        FlyCamera.gameObject.SetActive(false);

        // XR par défaut sur le PC
        //xrCamera.depth = 1;
        //FlyCamera.depth = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            usingSpectator = !usingSpectator;

            /*if (usingSpectator)
            {
                // Spectator prend la priorité sur le PC
                FlyCamera.depth = 2;
                xrCamera.depth = 1;
            }
            else
            {
                // XR reprend la priorité
                xrCamera.depth = 2;
                FlyCamera.depth = 1;
            }*/
            FlyCamera.gameObject.SetActive(!usingSpectator);
        }
    }
}
