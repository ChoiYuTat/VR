using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public string targetTag;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public AudioSource source;
    public AudioClip clip;
    public Transform head;
    public float spawnDistance = 2;
    public GameObject losemenu;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireBullet(ActivateEventArgs arg = null)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 1);
        source.PlayOneShot(clip);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == targetTag)
        {
            Destroy(bullet);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            losemenu.SetActive(!losemenu.activeSelf);

            losemenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
    }
}
