using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnTimeOut",1);
    }
    private void OnEnable()
    {
        audioSource.time = 0;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTimeOut()
    {
        audioSource.Stop();

        gameObject.SetActive(false);
    }
}
