using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Poison += Passout;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("sprite rend is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Passout() 
    {
        spriteRenderer.color = Color.red;
    
    }
    private void OnDestroy()
    {
        GameManager.Poison -= Passout;

    }
}
