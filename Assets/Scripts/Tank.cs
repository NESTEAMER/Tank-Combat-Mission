using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour

{
    //movement stuff
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    //weaponry stuff
    public GameObject projectilePrefab;
    public GameObject machineGunPrefab;
    public Transform projectileSpawnPoint;
    public float antiArmorCooldown = 3f; 
    private float nextAntiArmorFireTime = 0f;
    public float machineGunCooldown = 1.2f;
    private float nextMachineGunFireTime = 0f;
    public GameObject muzzleFlashPrefab;

    //health and game event stuff here
    public int hp = 100;
    public TextMeshProUGUI hpText;
    public bool isLevel1 = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Fire();
        HpUpdate();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
    }

    private void Fire()
    {
        //anti armor left click
        if (Input.GetButtonDown("Fire1") && Time.time > nextAntiArmorFireTime)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Instantiate(muzzleFlashPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            nextAntiArmorFireTime = Time.time + antiArmorCooldown;
        }

        //machine gun right click
        if (Input.GetButton("Fire2") && Time.time > nextMachineGunFireTime)
        {
            Instantiate(machineGunPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Instantiate(muzzleFlashPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            nextMachineGunFireTime = Time.time + machineGunCooldown;
        }
    }

    private void HpUpdate()
    {
        hpText.text = "HP: " + hp;  

        if(hp <= 0)
        {
            Die();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ArmorPiercingRound") || 
            collision.gameObject.CompareTag("SmallCaliber") || 
            collision.gameObject.CompareTag("Mine")) 
        {
            if (collision.gameObject.CompareTag("ArmorPiercingRound"))
            {
                hp -= 25; 
            }
            else if(collision.gameObject.CompareTag("SmallCaliber"))
            {
                hp -= 10; 
            }
            else if(collision.gameObject.CompareTag("Mine"))
            {
                hp -= 20;
            }

            //can't go below 0 no no
            hp = Mathf.Max(0, hp); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToxicRust"))
        {
            hp -= 25;
        }
    }

    void Die()
    {
        if (isLevel1)
        {
            SceneManager.LoadScene("Level 1"); 
        }
        else
        {
            SceneManager.LoadScene("Level 2"); 
        }
    }
}