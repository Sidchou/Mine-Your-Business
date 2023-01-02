using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text _scoreTxt;
    [SerializeField]
    TMP_Text _lifeTxt;
    int _score = 0;
    int _life = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLife() 
    {
        _life--;
        _lifeTxt.text = "Life: " + _life;
    }
    public void UpdateScore()
    {
        _score += 10; 
        _scoreTxt.text = "Score: " +_score;
    }

}
