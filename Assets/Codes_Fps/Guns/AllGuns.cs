using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllGuns:MonoBehaviour
{
    public GunsStat gunsStat;
    public int capacity;
    public float reloadTime, repeatTime, range;
    public GameObject gunPrefab;
    public GameObject bulletPrefab;
    public string gunName;
    public GameObject spawnPos;
    public AudioSource audioSource;
    public AudioClip clip;
    public  void Start()
    {
        capacity = gunsStat.capacity;
        reloadTime = gunsStat.reloadTime;
        repeatTime = gunsStat.repeatTime;
        range = gunsStat.range;
        gunName = gunsStat.gunName;
        gunPrefab = gunsStat.gunPrefab;

        bulletPrefab = gunsStat.bullertPrefab;
        GameObject cloneGun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        cloneGun.transform.SetParent(transform);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shot();
        }
    }
    public virtual void shot()
    {
        Instantiate(bulletPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
    }
    public virtual  void Reload()
    {

    }
    public abstract void Ultimate();

    public virtual void Sounds(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    
}
