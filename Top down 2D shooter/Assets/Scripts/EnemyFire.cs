using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 5f;
    public float smoothing = 0.01f;

    private bool isFiring = false;
    private bool isAimingAtPlayer;


    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Hero");
        isAimingAtPlayer = false;
    }

    private void Update()
    {
        AimToPlayer();

        
    }
    

    private void AimToPlayer()
    {
        //transform.LookAt(player.transform);

        Vector3 difference = player.transform.position - transform.position;

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ));

        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);

        isAimingAtPlayer = true;
        if (!isFiring)
        {
            Fire();
        }
    }

    private void Fire()
    {
        isFiring = true;

        if (isAimingAtPlayer == true)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            

            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }

            Invoke("SetFiring", fireTime);
        }
    }

    private void SetFiring()
    {
        isFiring = false;
    }
}
