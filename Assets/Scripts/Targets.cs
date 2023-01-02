using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour, ITargetable
{
    [SerializeField]
    private bool _danger = false;
    public float lifeTime { get; private set; } = 5;
    public float spawnTime { get; private set; } = 0;

    public void OnClick()
    {
        Destroy(gameObject);
        if (_danger)
            GameManager.Instance.uiManager.UpdateLife();
        else
            GameManager.Instance.uiManager.UpdateScore();

    }

    public void OnTimeOut()
    {
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-spawnTime>lifeTime)
        {
            OnTimeOut();
        }
    }

}
