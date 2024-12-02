using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class lose : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform head;
    public float spawnDistance = 2;
    public GameObject losemenu;
    public bool isLose;

    private void Start()
    {
        isLose = false;
    }
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        losemenu.transform.LookAt(new Vector3(head.position.x, losemenu.transform.position.y, head.position.z));
        losemenu.transform.forward *= -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLose)
        {
            if (other.CompareTag("bullet"))
            {
                losemenu.SetActive(!losemenu.activeSelf);
                losemenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                Time.timeScale = 0;
                Debug.Log(Time.timeScale);
                isLose = true;
            }
        }
    }
}
