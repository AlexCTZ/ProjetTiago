using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class Foam : MonoBehaviour
{
    public float power = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        // V�rifie si l'objet touch� contient un composant "Fire"
        Fire fire = other.GetComponent<Fire>();
        if (fire != null)
        {
            // R�duit la sant� du feu en fonction du power et du temps
            fire.ReduceHealth(power * Time.deltaTime);
        }
    }
}
