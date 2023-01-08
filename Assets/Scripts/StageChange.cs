using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();
    SpriteRenderer spriteRenderer;
    private int life = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer ==null)
        {
            Debug.LogError("spriterenderer is null");
        }
    }

    public void Damage() 
    {
        life++;
        if (life < sprites.Count)
            spriteRenderer.sprite = sprites[life];
        else
        {
            GameManager.Instance.GameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
