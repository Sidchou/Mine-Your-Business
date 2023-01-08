using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    [SerializeField]
    private float _spawnTime = 2;

    private  WaitForSeconds _wait;
    private Vector3 _spawnPos;

   

    // Start is called before the first frame update
    void Start()
    {
        _wait = new WaitForSeconds(_spawnTime);
        StartCoroutine("SpawnTarget") ;
        GameManager.GameOverEvent += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.targetPool.Activate(0);

        }
        */
    }
    void GameOver()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return _wait;

            _spawnPos = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-5f, 5f), 0);
            if (Random.value > 0.5)
            {
                GameManager.Instance.targetPool.Activate(0);
            }
            else
            {
                GameManager.Instance.targetPool.Activate(1);
            }
        }
    }



}
