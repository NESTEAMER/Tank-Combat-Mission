using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyTank : MonoBehaviour
{
   public GameObject projectilePrefab;
    public GameObject machineGunPrefab;
    public Transform projectileSpawnPoint;
    public float antiArmorCooldown = 3f;
    private float nextAntiArmorFireTime = 0f;
    public float machineGunCooldown = 1.2f;
    private float nextMachineGunFireTime = 0f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    public float maxHP = 100f;
    private float hp;
    public TextMeshProUGUI hpText;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomMovement());
        StartCoroutine(RandomShooting());

        hp = maxHP;
        UpdateHPText();
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            float randomRotation = Random.Range(-1f, 1f);
            float randomDuration = Random.Range(1f, 3f);

            transform.Rotate(Vector3.up * randomRotation * rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            yield return new WaitForSeconds(randomDuration);
        }
    }

    IEnumerator RandomShooting()
    {
        while (true)
        {
            float randomAntiArmorDelay = Random.Range(2f, 5f);
            float randomMachineGunDelay = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(randomAntiArmorDelay);

            if (Time.time > nextAntiArmorFireTime)
            {
                Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                nextAntiArmorFireTime = Time.time + antiArmorCooldown;
            }

            yield return new WaitForSeconds(randomMachineGunDelay);

            if (Time.time > nextMachineGunFireTime)
            {
                Instantiate(machineGunPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                nextMachineGunFireTime = Time.time + machineGunCooldown;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ArmorPiercingRound") ||
            collision.gameObject.CompareTag("SmallCaliber"))
        {
            if (collision.gameObject.CompareTag("ArmorPiercingRound"))
            {
                hp -= 25;
            }
            else
            {
                hp -= 10;
            }

            hp = Mathf.Max(0, hp);

            UpdateHPText();

            if (hp <= 0f)
            {
                Die();
            }
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {hp}";
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
