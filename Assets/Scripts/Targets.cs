using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour, ITargetable
{
    [SerializeField]
    private bool _danger  = false;
     public float lifeTime { get; set; } = 5;
    public float spawnTime { get; set; } = 0;

    public void OnClick()
    {
        GameManager.Instance.targetPool.Deactivate(this.gameObject);
        if (_danger)
            GameManager.Instance.uiManager.UpdateLife();
        else
            GameManager.Instance.uiManager.UpdateScore();

    }

    public void OnTimeOut()
    {

        GameManager.Instance.targetPool.Deactivate(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void OnEnable()
    {
        
        spawnTime = Time.time;
        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-5f, 5f), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifeTime)
        {
            OnTimeOut();
        }
    }

}
