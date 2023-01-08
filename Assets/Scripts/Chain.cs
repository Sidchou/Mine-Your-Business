using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Lantern.BadCoal += Shake;
    }

    // Update is called once per frame
    void Shake()
    {
        animator.SetTrigger("Shake");
    }
    private void OnDisable()
    {
        Lantern.BadCoal -= Shake;

    }
}
