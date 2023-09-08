using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private ParticleSystem _psPlayer;
    [SerializeField] private Transform _trRespawn;

    private bool _isDead = false;
    private ParticleSystem _spawnedParticleSystem;

    void Start()
    {

    }
    void Update()
    {
        if(!GlobalVariables.isPlayerAlive && !_isDead)
        {
            Destroy(_spawnedParticleSystem);
            _isDead = true;
            _player.SetActive(false);
            _spawnedParticleSystem = Instantiate(_psPlayer, _player.transform.position, Quaternion.identity);
            StartCoroutine(_enumWaitToRespawn(3f));
        }
    }

    private IEnumerator _enumWaitToRespawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(_spawnedParticleSystem);
        _player.SetActive(true);
        _player.transform.position = _trRespawn.position;
        GlobalVariables.isPlayerAlive = true;
        _isDead = false;
        GlobalVariables.IndexCameraPosition = 0;
    }
}
