using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class TargetPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _targets;
    [SerializeField]

    private List<GameObject> _targetActivePool;
    [SerializeField]

    private List<GameObject> _targetInactivePool;
    [SerializeField]
    private int _poolCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }
    void Populate()
    {
        GameObject go;
        for (int i = 0; i < _poolCount/2; i++)
        {
             go = Instantiate(_targets[0],Vector3.zero,Quaternion.identity,this.transform);
            go.SetActive(false);
            _targetInactivePool.Add(go);
        }
        for (int i = 0; i < _poolCount / 2; i++)
        {
            go = Instantiate(_targets[1], Vector3.zero, Quaternion.identity, this.transform);
            go.SetActive(false);
            _targetInactivePool.Add(go);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate(int i) 
    {
        string name = _targets[i].name;
        GameObject go = _targetInactivePool.Find(o => o.name.Contains(name));
        if (go == null)
        {
            go = Instantiate(_targets[i], Vector3.zero, Quaternion.identity, this.transform);
        }
        go.SetActive(true);
        _targetInactivePool.Remove(go);
        _targetActivePool.Add(go);

    }
    
    public void Deactivate(GameObject go)
    {
        // GameObject go = _targetInactivePool.Find(o => o.name.Contains(name));
        go.SetActive(false);

        _targetActivePool.Remove(go);
        _targetInactivePool.Add(go);
    }
}

