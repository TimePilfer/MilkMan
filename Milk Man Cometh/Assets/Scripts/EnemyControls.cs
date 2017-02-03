using UnityEngine;
using System.Collections;

public class EnemyControls : BasicControls
{
    void Throw()
    {
        anim.SetTrigger("Throw");
    }

    void Unthrow()
    {
        anim.ResetTrigger("Throw");
    }

    void Grab()
    {
        anim.SetTrigger("Grab");
    }

    void Ungrab()
    {
        anim.ResetTrigger("Grab");
    }

    void Hit()
    {
        anim.SetTrigger("Hit");
    }

    void Unhit()
    {
        anim.ResetTrigger("Hit");
    }


}
