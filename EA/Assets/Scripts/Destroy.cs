using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public GameObject[] enemies;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene("");
        }
    }

}
