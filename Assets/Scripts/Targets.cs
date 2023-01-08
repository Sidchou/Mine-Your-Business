using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour, ITargetable
{
    [SerializeField]
    private bool _danger  = false;
     public float lifeTime { get; set; } = 5;
    public float spawnTime { get; set; } = 0;

    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private PolygonCollider2D polygonCollider;
    [SerializeField]
    List<Vector2[]> colliderBoarder;

    public void OnClick()
    {
        GameManager.Instance.targetPool.Deactivate(this.gameObject);
        if (_danger)
        {
            //GameManager.Instance.uiManager.UpdateLife();
            GameManager.Instance.lantern.AnimateBadCoal();
            GameManager.Instance.stageChange.Damage();
        }
        else
        {
            GameManager.Instance.uiManager.UpdateScore();
            GameManager.Instance.lantern.AnimateGoodCoal();

        }
    }

    public void OnTimeOut()
    {

        GameManager.Instance.targetPool.Deactivate(this.gameObject);
    }
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogError("spriteRenderer is null");
        GetBoarder();
    }

    void GetBoarder()
    {
        colliderBoarder = new List<Vector2[]>();
        for (int i = 0; i < sprites.Length; i++)
        {
            colliderBoarder.Add(polygonCollider.GetPath(i));
        }
        polygonCollider.pathCount = 1;
    }
    void SwitchBoarder(int select)
    {
        spriteRenderer.sprite = sprites[select];
        polygonCollider.SetPath(0, colliderBoarder[select]);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameOverEvent += GameOver;

    }


    private void OnEnable()
    {
        SwitchBoarder(Random.Range(0,sprites.Length));
        transform.localScale = Vector3.one * Random.Range(0.9f,1.0f);
        transform.Rotate(Vector3.forward*Random.Range(0,360));
        spawnTime = Time.time;
        transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > lifeTime )
        {
             OnTimeOut();
        }

    }
    void GameOver()
    {
        OnTimeOut();
    }
    private void OnValidate()
    {
    }

}
