using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour
{
    #region inspector variables
    [SerializeField]
    [Header("Variables for player controller")]
    private MovementController playerController;
    #endregion

    #region events listeners
    private void OnEnable()
    {
        Debug.Log("Subsc");
        playerController.OnIdleEvent += OnPlayerIdle;
        playerController.OnMovementEvent += OnPlayerMovement;
        playerController.OnAtackEvent += OnPlayerAtack;
        playerController.OnStopAtackEvent += OnPlayerStopAtack;
    }

    private void OnDisable()
    {
        Debug.Log("Unsubsc");
        playerController.OnIdleEvent -= OnPlayerIdle;
        playerController.OnMovementEvent -= OnPlayerMovement;
        playerController.OnAtackEvent -= OnPlayerAtack;
        playerController.OnStopAtackEvent -= OnPlayerStopAtack;
    }
    #endregion

    #region private methods
    private void OnPlayerMovement()
    {
        playerController.GetAnimator.SetBool("walk", true);
    }

    private void OnPlayerIdle()
    {
        playerController.GetAnimator.SetBool("walk", false);
    }

    private void OnPlayerAtack()
    {
        playerController.GetAnimator.SetBool("atack", true);
    }

    private void OnPlayerStopAtack()
    {
        playerController.GetAnimator.SetBool("atack", false);
    }
    #endregion
}



