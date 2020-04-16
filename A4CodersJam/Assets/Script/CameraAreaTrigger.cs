using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CoderJam;

[RequireComponent(typeof(Collider2D))]
public abstract class CameraAreaTrigger : MonoBehaviour
{
    protected BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D triggeredCollider)
    {
        Player playerController = triggeredCollider.GetComponentInParent<Player>();
        if (null == playerController) return;

        playerController.EnterArea(this);


    }

    private void OnTriggerExit2D(Collider2D triggeredCollider)
    {
        Player playerController = triggeredCollider.GetComponentInParent<Player>();
        if (null == playerController) return;

        playerController.ExitArea(this);
    }

    public abstract void Activate(Player playerController);
    public abstract void Deactivate(Player playerController);
}
