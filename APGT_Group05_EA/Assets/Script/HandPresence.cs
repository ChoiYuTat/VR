using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty gripAnimationAction;
    public InputActionProperty triggerAnimationAction;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        Debug.Log(gameObject.name + " " + gripValue);
        anim.SetFloat("grip", gripValue);

        float triggerValue = triggerAnimationAction.action.ReadValue<float>();
        Debug.Log(gameObject.name + " " + triggerValue);
        anim.SetFloat("Trigger", triggerValue);
    }
}
