using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [System.Serializable]
    public enum SwitchMode
    {
        OneWay,
        TwoWay,
        Disabled
    }
    public SwitchMode switchMode;

    [System.Serializable]
    public enum SwitchType
    {
        GameObject,
        Material,
        Sprite,        
        None
    }
    public SwitchType switchType;

    [SerializeField] string playerTag = "Player";
    [SerializeField] KeyCode interactKey = KeyCode.Space;
    [SerializeField] AudioClip switchClip;
    public bool switchOn = false;

    [Header("Switch is Material")]
    [SerializeField] Renderer targetRenderer;
    [SerializeField] Material startMaterial;
    [SerializeField] Material endMaterial;

    [Header("Switch is GameObject)")]
    [SerializeField] GameObject startObject;
    [SerializeField] GameObject endObject;

    [Header("Switch is Sprite")]
    [SerializeField] SpriteRenderer targetSpriteRenderer;
    [SerializeField] Sprite startSprite;
    [SerializeField] Sprite endSprite;

    AudioSource audioSource;

    bool allowInteract = false;
    bool doOnce = false;
    
    void Start()
    {
        if (switchType == SwitchType.GameObject && startObject != null && endObject != null)
        {
            if (!switchOn)
            {
                startObject.SetActive(true);
                endObject.SetActive(false);
            }
            else
            {
                startObject.SetActive(false);
                endObject.SetActive(true);
            }
        }

        if (switchType == SwitchType.Material && startMaterial != null && endMaterial != null)
        {
            targetRenderer = GetComponentInChildren<Renderer>();
            if(targetRenderer != null)
            {
                if (!switchOn) targetRenderer.material = startMaterial;
                else targetRenderer.material = endMaterial;
            }
        }

        if (switchType == SwitchType.Sprite && startSprite != null && endSprite != null)
        {
            targetSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if(targetSpriteRenderer != null)
            {
                if (!switchOn) targetSpriteRenderer.sprite = startSprite;
                else targetSpriteRenderer.sprite = endSprite;
            }            
        }

        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && allowInteract)
        {
            switch (switchMode)
            {
                case SwitchMode.OneWay:
                    if (!switchOn)
                    {
                        switch (switchType)
                        {
                            case SwitchType.GameObject:
                                if (startObject != null && endObject != null)
                                {
                                    startObject.SetActive(false);
                                    endObject.SetActive(true);
                                }
                                break;
                            case SwitchType.Material:
                                if (targetRenderer != null && targetRenderer.material != endMaterial)
                                    targetRenderer.material = endMaterial;
                                break;
                            case SwitchType.Sprite:
                                if (targetSpriteRenderer != null && targetSpriteRenderer.sprite != endSprite)
                                    targetSpriteRenderer.sprite = endSprite;
                                break;
                        }
                        PlayAudio();
                        switchOn = true;
                    }
                    break;
                case SwitchMode.TwoWay:
                    switchOn = !switchOn;
                    switch (switchType)
                    {
                        case SwitchType.GameObject:
                            if (startObject != null && endObject != null)
                            {
                                if (switchOn)
                                {
                                    startObject.SetActive(false);
                                    endObject.SetActive(true);
                                }
                                else
                                {
                                    startObject.SetActive(true);
                                    endObject.SetActive(false);
                                }
                            }
                            break;
                        case SwitchType.Material:
                            if (targetRenderer != null && startMaterial != null && endMaterial != null)
                            {
                                if (switchOn) targetRenderer.material = endMaterial;
                                else targetRenderer.material = startMaterial;
                            }
                            break;
                        case SwitchType.Sprite:
                            if (targetSpriteRenderer != null && startSprite != null && endSprite != null)
                            {
                                if (switchOn) targetSpriteRenderer.sprite = endSprite;
                                else targetSpriteRenderer.sprite = startSprite;
                            }
                            break;
                    }

                    PlayAudio();
                    break;
                case SwitchMode.Disabled:
                    break;
                default:
                    break;
            }

        }

        // for trap use
        if(allowInteract && switchType == SwitchType.None && switchMode == SwitchMode.OneWay)
        {
            
            if (!doOnce)
            {
                switchOn = true;
                PlayAudio();
                doOnce = true;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag) allowInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag) allowInteract = false;
    }

    private void PlayAudio()
    {
        if (audioSource != null && switchClip != null)
        {
            audioSource.clip = switchClip;
            audioSource.Play();
        }
    }
}
