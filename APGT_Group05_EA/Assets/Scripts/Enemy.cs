using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Enemy : MonoBehaviour
{
    Animator anim;
    public bool dead;
    public Transform weaponHolder;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RandomAnimation());

        if (weaponHolder.GetComponentInChildren<Weapon>() != null)
            weaponHolder.GetComponentInChildren<Weapon>().active = false;

    }

    void Update()
    {
        if (!dead)
            transform.LookAt(new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z));


    }

    public void Ragdoll()
    {
        anim.enabled = false;
        Body[] parts = GetComponentsInChildren<Body>();
        foreach (Body bp in parts)
        {
            bp.rb.isKinematic = false;
            bp.rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
        dead = true;

        if (weaponHolder.GetComponentInChildren<Weapon>() != null)
        {
            Weapon w = weaponHolder.GetComponentInChildren<Weapon>();
            w.Release();

        }
    }

    public void Shoot()
    {
        if (dead)
            return;

        if (weaponHolder.GetComponentInChildren<Weapon>() != null)
            weaponHolder.GetComponentInChildren<Weapon>().Shoot(GetComponentInChildren<ParticleSystem>().transform.position, transform.rotation, true);
    }

    IEnumerator RandomAnimation()
    {
        anim.enabled = false;
        yield return new WaitForSecondsRealtime(Random.Range(.1f, .5f));
        anim.enabled = true;

    }
}
