using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerAnimation : MonoBehaviour
{
    public List<AnimationStateData> animationStates = new List<AnimationStateData>();
    private SpriteRenderer spriteRenderer;
    private Dictionary<PlayerAnimationState, AnimationData> animationDictionary = new Dictionary<PlayerAnimationState, AnimationData>();
    bool isPlaying = false;
    public PlayerAnimationState currentState = PlayerAnimationState.IDLE_DOWN;
    public void Start()
    {
        InitializeDictionary();
        spriteRenderer = GetComponent<SpriteRenderer>();

        TopDownPlayerMovement topDownPlayerMovement = GetComponent<TopDownPlayerMovement>();
        topDownPlayerMovement.OnMove += SetAnimationState;
    }

    public void InitializeAnimation(AnimationData animation)
    {
        StopAllCoroutines();
        StartCoroutine(PlayAnimation(animation));
    }

    public void SetAnimationState(Vector2 moveDirection)
    {
        if(moveDirection == Vector2.zero)
        {
            currentState = GetIdleState(currentState);
        }

        if(moveDirection.y < 0)
        {
            currentState = PlayerAnimationState.WALK_DOWN;
            InitializeAnimation(animationDictionary[PlayerAnimationState.WALK_DOWN]);
        }
        else if(moveDirection.y > 0)
        {
            currentState = PlayerAnimationState.WALK_UP;
            InitializeAnimation(animationDictionary[PlayerAnimationState.WALK_UP]);
        }
        if(moveDirection.x < 0)
        {
            currentState = PlayerAnimationState.WALK_LEFT;
            InitializeAnimation(animationDictionary[PlayerAnimationState.WALK_LEFT]);
        }
        else if(moveDirection.x > 0)
        {
            currentState = PlayerAnimationState.WALK_RIGHT;
            InitializeAnimation(animationDictionary[PlayerAnimationState.WALK_RIGHT]);
        }

        
        //idle check
        

        // create animation assets for remaining walk cycles

        // call InitializeAnimation based on the direction the player is moving
        

    }

    public PlayerAnimationState GetIdleState(PlayerAnimationState _currentState)
    {
        PlayerAnimationState tmp = PlayerAnimationState.IDLE_DOWN;
        switch(_currentState)
        {
            case PlayerAnimationState.WALK_UP:
                tmp = PlayerAnimationState.IDLE_UP;
                break;
            case PlayerAnimationState.WALK_DOWN:
                tmp = PlayerAnimationState.IDLE_DOWN;
                break;
            case PlayerAnimationState.WALK_LEFT:
                tmp = PlayerAnimationState.IDLE_LEFT;
                break;
            case PlayerAnimationState.WALK_RIGHT:
                tmp = PlayerAnimationState.IDLE_RIGHT;
                break;
        }
        return tmp;
    }

    private IEnumerator PlayAnimation(AnimationData animation)
    {
        isPlaying = true;
        spriteRenderer.sprite = animation.frames[0];
        int frameCount = animation.frames.Length;
        int frameIndex = 0;

        while (isPlaying)
        {
            yield return new WaitForSeconds(animation.frameDelay);
            frameIndex++;
            if(frameIndex >= frameCount) { frameIndex = 0; }
            spriteRenderer.sprite = animation.frames[frameIndex];

            yield return null;
        }

        yield return null;
    }

    public void StopAnimation() { isPlaying = false; }
    public void InitializeDictionary()
    {
        foreach (AnimationStateData animationStateData in animationStates)
        {
            animationDictionary.Add(animationStateData.state, animationStateData.animation);
        }
    }
}
[CreateAssetMenu(fileName = "AnimationSO", menuName = "AnimationSO")]
public class AnimationData:ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;
}

public enum PlayerAnimationState
{
    WALK_UP,
    WALK_DOWN,
    WALK_LEFT,
    WALK_RIGHT,
    IDLE_UP,
    IDLE_DOWN,
    IDLE_LEFT,
    IDLE_RIGHT
   
}

[Serializable]
public class AnimationStateData
{
    public PlayerAnimationState state;
    public AnimationData animation;
}

