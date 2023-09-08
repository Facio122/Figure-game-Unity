using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _audioBackGround;
    [SerializeField] AudioSource _audioJump;
    [SerializeField] AudioSource _audioCoinPick;
    void Start()
    {
        _funSetAudioBackGround();
        _funSetAudiojump();
        _funSetAudioCoinPick();
    }

    void Update()
    {
        _funPlayJump();
        _funPlayCoinPick();
    }
    private void _funSetAudioBackGround()
    {
        _audioBackGround.Play();
        _audioBackGround.loop = true;
        _audioBackGround.volume = 0.25f;
    }
    private void _funSetAudiojump()
    {
        _audioJump.volume = 0.25f;
    }
    private void _funSetAudioCoinPick()
    {
        _audioCoinPick.volume = 0.05f;
    }
    private void _funPlayJump()
    {
        if(GlobalVariables.isJump)
        {
            _audioJump.pitch = Random.Range(0.5f, 2.0f);
            _audioJump.Play();
        }
    }
    private void _funPlayCoinPick()
    {
        if (GlobalVariables.isCoinPick)
        {
            _audioCoinPick.Play();
            GlobalVariables.isCoinPick = false;
        }
    }
}
