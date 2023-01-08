using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poison : MonoBehaviour
{
    [SerializeField]
    private float _alpha = 0.75f;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private WaitForEndOfFrame _wait;
    private Color _color;
    // Start is called before the first frame update
    void Start()
    {
        _color = _image.color;
        _color.a = 0;
        _image.color = _color;
        Invoke("Poisoned", 1) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Poisoned()
    {
        StartCoroutine(PoinsonRoutine());
    }
    IEnumerator PoinsonRoutine()
    {
        while (_color.a < _alpha)
        {
            _color.a += 0.01f;
            _image.color =_color;
            yield return _wait;
        }
    }
}
