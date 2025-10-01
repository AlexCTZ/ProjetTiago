using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] GameObject foamGo;
    //[SerializeField] GameObject colliderGo;
    [Tooltip("Number of points per second it kills a Fire")]

    XRGrabInteractable xrGrab;

    void Start()
    {
        // Récupérer le composant XRGrabInteractable
        xrGrab = GetComponent<XRGrabInteractable>();

        // S’enregistrer sur les événements "activated" et "deactivated"
        xrGrab.activated.AddListener(OnActivated);
        xrGrab.deactivated.AddListener(OnDeactivated);

        // Désactiver la mousse et le collider au départ
        setActivation(false);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        setActivation(true);
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        setActivation(false);
    }

    private void setActivation(bool active)
    {
        // Affiche ou cache la mousse
        if (foamGo != null)
            foamGo.SetActive(active);
            Debug.Log(active);
        // Active ou désactive le collider de l’extincteur
        //if (colliderGo != null)
            //colliderGo.SetActive(active);
    }
}
