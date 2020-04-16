using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoderJam;


public class CameraFollowAreaTrigger : CameraAreaTrigger
{

    public override void Activate(Player playercontroller)
    {
        CameraManager2D.instance.followTarget = playercontroller.transform;

        CameraManager2D.CameraBounds bounds = new CameraManager2D.CameraBounds();
        bounds.Left = _collider.bounds.min.x;
        bounds.Right = _collider.bounds.max.x;
        bounds.Bottom = _collider.bounds.min.y;
        bounds.Top = _collider.bounds.max.y;

        CameraManager2D.instance.SetBound(bounds);
    }

    public override void Deactivate(Player playercontroller)
    {
        CameraManager2D.instance.ResetBounds();
    }

    private void OnDrawGizmos()
    {
        _collider = GetComponent<BoxCollider2D>();
        if (null == _collider) return;

        Color color = Color.yellow;
        color.a = 0.2f;
        Gizmos.color = color;
        Gizmos.DrawCube(_collider.bounds.center, _collider.bounds.size);
    }
}
