using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public abstract class PickUp : MonoBehaviour
{
    [Header("Feedback")]
    [SerializeField] AudioClip _pickupSFX = null;
    [SerializeField] ParticleSystem _particlePrefab = null;
    [SerializeField] float rotationSpeed;
    Collider _collider = null;
    AudioSource _audioSource = null;
    protected abstract void OnPickUp(PlayerFateAchievement playerFate);

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    private void Reset()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        PlayerFateAchievement playerFate = other.GetComponent<PlayerFateAchievement>();
        if (playerFate == null)
            return;

      
        OnPickUp(playerFate);

        if (_pickupSFX != null)
        {
            SpawnAudio(_pickupSFX);
        }

        if (_particlePrefab != null)
        {
            SpawnParticle(_particlePrefab);
        }

        Disable();
    }
    void SpawnAudio(AudioClip pickupSFX)
    {
        AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
    }

    void SpawnParticle(ParticleSystem pickupParticles)
    {
        ParticleSystem newParticles =
            Instantiate(pickupParticles, transform.position, Quaternion.identity);
        newParticles.Play();
    }

    // allow override in case subclass wants to object pool, etc.
    protected virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}
