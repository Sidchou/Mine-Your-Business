using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance ;
    public static GameManager Instance
    {
        get 
        {
            if(_instance == null)
                _instance = new GameManager();
            return _instance; 
        }
         }
    [SerializeField]
    public TargetSpawn targetSpawn;
    [SerializeField]
    public UIManager uiManager;
    [SerializeField]
    public TargetPool targetPool; 

    private Vector2 _worldPoint;
    private RaycastHit2D _hit;

    public static Action Poison;
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

             _worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition+Vector3.forward * 10);
             _hit = Physics2D.Raycast(_worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (_hit.collider != null)
            {

                ITargetable obj = _hit.collider.GetComponent<ITargetable>();
                if (obj != null)
                {
                    obj.OnClick();
                }

            }
        }
    }

}


