using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionSwitchTrigger : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D _dummyPlayer;
    public GameManager gm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "DummyPlayer")
        {
            
            _dummyPlayer.SwitchDirection();
        }
    }

    //private void OnMouseDown()
    //{
    //    gm.WaitAfterRemoveDirectionSwitch();
    //    Destroy(this.gameObject);
    //}
    // Start is called before the first frame update
    void Start()
    {
        _dummyPlayer = GameObject.Find("DummyPlayer").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
