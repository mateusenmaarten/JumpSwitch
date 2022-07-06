using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector3 mouseWorldPos;
    public GameObject jump;
    public GameObject directionSwitch;
    public bool JumpCoolDownIsActive;
    public bool SwitchDirectionCoolDownIsActive;
    public float PlacementDelay = 2f;

    public CharacterController2D DummyPlayer;

    public Timer Timer;

    private int _jumpCount = 0;
    private int _turnCount = 0;
    private int _livesCount = 3;

    //UI
    [SerializeField]
    private Text _jumpCountText;
    [SerializeField]
    private Text _turnCountText;
    [SerializeField]
    private Text _livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !JumpCoolDownIsActive)
        {
            PlaceJumpTrigger();
        }

        if (Input.GetMouseButtonDown(1) && !SwitchDirectionCoolDownIsActive)
        {
            PlaceSwitchDirectionTrigger();
        }
    }

    private void PlaceSwitchDirectionTrigger()
    {
        mouseWorldPos.z = 0f;
        Instantiate(directionSwitch, mouseWorldPos, Quaternion.identity);
        SwitchDirectionCoolDownIsActive = true;

        _turnCount += 1;
        _turnCountText.text = _turnCount.ToString();

        StartCoroutine(WaitForDirectionSwitch(PlacementDelay));
    }

    public void PlaceJumpTrigger()
    {
        mouseWorldPos.z = 0f;
        Instantiate(jump, mouseWorldPos, Quaternion.identity);
        JumpCoolDownIsActive = true;

        _jumpCount += 1;
        _jumpCountText.text = _jumpCount.ToString();

        StartCoroutine(WaitForJump(PlacementDelay));
    }
    public void WaitAfterRemoveJump()
    {
        StartCoroutine(WaitForJump(PlacementDelay));
    }
    public void WaitAfterRemoveDirectionSwitch()
    {
        StartCoroutine(WaitForDirectionSwitch(PlacementDelay));
    }

    public void OnDeath() 
    {
        _livesCount -= 1;
        _livesText.text = _livesCount.ToString();

        Debug.Log(_livesCount);

        if (_livesCount > 0)
        {
            ResetScene();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ResetScene() 
    {
        Timer.ResetTimer();
        ResetDummyPlayerToStartPosition();
    }

    public void ResetDummyPlayerToStartPosition()
    {
        DummyPlayer.transform.position = DummyPlayer.StartPosition;
    }


    IEnumerator WaitForJump(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);   //Wait
        JumpCoolDownIsActive = false;
        Debug.Log("End Wait() function and the time is: " + Time.time);
    }
    IEnumerator WaitForDirectionSwitch(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);   //Wait
        SwitchDirectionCoolDownIsActive = false;
        Debug.Log("End Wait() function and the time is: " + Time.time);
    }
}
