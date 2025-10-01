using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float explosionRadius = 5f;
    public float extinguishPower = 100f;
    public ParticleSystem explosionEffect;
    public AudioSource explosionSound;
    public AudioSource pinSound;

    [Header("Grenade State")]
    public GameObject pinObject;
    private bool isArmed = false;
    private bool hasExploded = false;

    XRGrabInteractable grab;
    private bool isCountingDown = false;
    private float explosionDelay = 1f;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();

        // Pour activer la fonction de dégoupillage via bouton secondaire
        grab.selectExited.AddListener(OnReleased);
        grab.activated.AddListener(OnActivated);
    }

    void OnActivated(ActivateEventArgs args)
    {
        ArmGrenade();
    }

    void OnReleased(SelectExitEventArgs args)
    {
        if (isArmed && !isCountingDown && !hasExploded)
        {
            isCountingDown = true;
            StartCoroutine(DelayedExplosion());
        }
    }

    IEnumerator DelayedExplosion()
    {
        yield return new WaitForSeconds(explosionDelay);

        if (!hasExploded)
        {
            Explode();
        }
    }

    public void ArmGrenade()
    {
        if (isArmed) return;

        isArmed = true;
        if (pinSound != null)
            pinSound.Play();

        if (pinObject != null)
            Destroy(pinObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasExploded || !isArmed) return;

        Explode();
        hasExploded = true;
    }

    void Explode()
    {

        // Effets
        if (explosionEffect != null)
            explosionEffect.Play();

        if (explosionSound != null)
            explosionSound.Play();

        // Éteindre les feux dans la zone
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            Fire fire = hit.GetComponent<Fire>();
            if (fire != null)
            {
                fire.ReduceHealth(extinguishPower);
            }
        }

        // Désactiver la grenade
        StartCoroutine(DestroyAfterEffects());
    }

    IEnumerator DestroyAfterEffects()
    {
        float delay = explosionEffect != null ? explosionEffect.main.duration : 2f;

        GetComponent<Collider>().enabled = false;
        if (TryGetComponent<MeshRenderer>(out var renderer))
            renderer.enabled = false;

        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
