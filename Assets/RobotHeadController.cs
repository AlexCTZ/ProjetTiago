using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RobotHeadController : MonoBehaviour
{
    public GameObject head;
    public Rigidbody headRigidbody;
    public XRSocketInteractor socket;
    public ParticleSystem fireParticles;
    public Fire fire;
    public Vector3 jumpForce = new Vector3(2f, 5f, 0);
    private XRGrabInteractable xrGrab;

    private void Start()
    {
        xrGrab = head.GetComponent<XRGrabInteractable>();
    }

    public void StartFire()
    {
        xrGrab.enabled = false;
        transform.parent = null;
        headRigidbody.AddForce(jumpForce, ForceMode.Impulse);
        fire.gameObject.SetActive(true);
        fireParticles.Play();
    }

    public void StopFire()
    {
        fireParticles.Stop();
        fire.gameObject.SetActive(false);
        if (xrGrab != null)
            xrGrab.enabled = true;
    }
}
