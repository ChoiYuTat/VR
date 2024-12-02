using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform head;
    public float spawnDistance = 2;
    public GameObject winmenu;
    bool isWin;

    private void Start()
    {
        isWin = false;
    }
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (!isWin)
        {
            if (enemies.Length == 0)
            {
                winmenu.SetActive(!winmenu.activeSelf);
                winmenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                isWin = true;
            }
        }
                winmenu.transform.LookAt(new Vector3(head.position.x, winmenu.transform.position.y, head.position.z));
        winmenu.transform.forward *= -1;
    }

}
