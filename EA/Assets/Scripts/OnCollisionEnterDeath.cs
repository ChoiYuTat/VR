using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{
    public string[] targetTags;
    public Enemy enemy;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var tag in targetTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                enemy.Dead(collision.contacts[0].point);
                return;
            }
        }
    }
}
