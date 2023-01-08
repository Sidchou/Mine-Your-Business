using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSoundPool : MonoBehaviour
{
    [SerializeField]
    GameObject _sound;
    [SerializeField]
    List<GameObject> _soundPool = new List<GameObject>();
    [SerializeField]
    int _n = 10;
    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }
    void Populate()
    {
        GameObject s;
        for (int i = 0; i < _n; i++)
        {
             s = Instantiate(_sound);
            s.transform.parent = transform;
            _soundPool.Add(s);
            s.SetActive(false);
        }
        
    
    }
    public GameObject Request()
    {
        foreach (var item in _soundPool)
        {
            if (item.activeInHierarchy ==false)
            {
                item.SetActive(true);
                return item;
            }
        }
        GameObject s = Instantiate(_sound);
        s.transform.parent = transform;
        _soundPool.Add(s);

        return s;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
