using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageCanvasAnimator : MonoBehaviour
{

    // set the controller you want to use in the inspector
    public RuntimeAnimatorController controller;

    // the UI/Image component
    Image imageCanvas;
    // the fake SpriteRenderer
    SpriteRenderer fakeRenderer;
    // the Animator
    Animator animator;


    void Start()
    {
        imageCanvas = GetComponentInChildren<Image>();
        fakeRenderer = GetComponentInChildren<SpriteRenderer>();
        // avoid the SpriteRenderer to be rendered
        fakeRenderer.enabled = false;
        animator = GetComponentInChildren<Animator>();
        controller = animator.runtimeAnimatorController;
    }

    void Update()
    {
        // if a controller is running, set the sprite
        if (animator.runtimeAnimatorController)
        {
            imageCanvas.sprite = fakeRenderer.sprite;
        }
    }

}
