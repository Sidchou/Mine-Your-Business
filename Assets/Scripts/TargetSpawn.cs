using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _safeTarget;
    [SerializeField]
    private GameObject _dangerTarget;
    [SerializeField]
    private float _spawnTime = 2;

    private  WaitForSeconds _wait;
    private Vector3 _spawnPos;
    private GameObject _spawndTarget;

    // Start is called before the first frame update
    void Start()
    {
        _wait = new WaitForSeconds(_spawnTime);
        StartCoroutine(SpawnTarget()) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            _spawnPos = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-5f, 5f), 0);
            if (Random.value > 0.5)
            {
                Instantiate(_safeTarget, _spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(_dangerTarget, _spawnPos, Quaternion.identity);
            }
            yield return _wait;
        }
    }
}
