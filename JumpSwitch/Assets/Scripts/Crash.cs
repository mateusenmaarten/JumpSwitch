using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crash : MonoBehaviour
{

    [SerializeField]
    private GameManager _gm; 

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DummyPlayer")
        {
            _gm.OnDeath();
        }
    }
}
