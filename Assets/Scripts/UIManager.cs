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
    static int _score = 0;
    static int _life = 5;
    [SerializeField]
    TMP_Text _gameover;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameOverEvent += GameOver;
        GameManager.PoisonEvent += GameOver;

    }
    private void OnDisable()
    {
        void Start()
        {
            GameManager.GameOverEvent -= GameOver;
            GameManager.PoisonEvent -= GameOver;

        }
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
    private void GameOver()
    {
        _gameover.gameObject.SetActive(true);
    }

}
