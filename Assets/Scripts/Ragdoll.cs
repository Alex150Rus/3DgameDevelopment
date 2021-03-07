using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Задача: обойти все кости и выключить на них RB и collider, включить основной капсульный коллайдер, аниматор и основной RB
// кодга умираем - отключаем родительский коллайдер и Rb и включаем детские (те которые выше выключили)
public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float killForce = 5f;
    [SerializeField] private bool kill;
    [SerializeField] private bool revive;

    //массивы с костями
    [SerializeField] private Rigidbody[] RBs;
    [SerializeField] private Collider[] colls;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        RBs = GetComponentsInChildren<Rigidbody>();
        colls = GetComponentsInChildren<Collider>();
        Revive();
    }

    private void Kill()
    {
        kill = false;
        SetRagdoll(true);
        SetMain(false);
    }

    private void Revive()
    {
        revive = false;
        SetRagdoll(false);
        SetMain(true);
    }

    private void SetRagdoll(bool active)
    {
        for (int i = 0; i < RBs.Length; i++)
        {
            RBs[i].isKinematic = !active;
        }

        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = active;
        }
    }

    private void SetMain(bool active)
    {
        anim.enabled = active;
        RBs[0].isKinematic = !active;
        colls[0].enabled = active;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Revive();
        }
    }
}
