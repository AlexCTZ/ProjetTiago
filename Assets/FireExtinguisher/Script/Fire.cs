using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Tooltip("The maximum value of health")]
    [SerializeField] private float maxHealth;

    [Tooltip("How much health per secondes the fire gain when not extinguished")]
    [SerializeField] private float healthIncreasePerSec;


    [Tooltip("What scale to apply according to the health")]
    [SerializeField] private float scalePerHealth;

    [SerializeField] private float health;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            UpdateHealth();
        }
    }

    public GameObject fire;
    public Vector3 maxScale = new Vector3(1f, 1f, 1f);
    public Vector3 minScale = new Vector3(0.1f, 0.1f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        // TODO
        fire.SetActive(true);
        health = 70;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO
        UpdateHealth();
    }

    void UpdateHealth()
    {
        // activate/deactivate gameObject if health > 0
        // TODO
        if (health <= 0)
        {
            fire.SetActive(false);
        }
        else
        {
            fire.SetActive(true);
        }


        // Gain health if fire is not fully extinguished
        // TODO
        if (health < maxHealth)
        {
            health += healthIncreasePerSec * Time.deltaTime;
        }

        // Update scale according to Health
        // TODO
        float healthRatio = Mathf.Clamp01(health / maxHealth);
        transform.localScale = Vector3.Lerp(minScale, maxScale, healthRatio);

    }

    public void ReduceHealth(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            health = 0f;
            Extinguish();
        }
    }

    [Header("Références")]
    public RobotHeadController robotHeadController;


    private void Extinguish()
    {
        // Code pour éteindre le feu : particules, sons, désactivation...
        Debug.Log("Le feu est éteint !");
        fire.SetActive(false);

        if (robotHeadController != null)
        {
            robotHeadController.StopFire();
        }
    }
}