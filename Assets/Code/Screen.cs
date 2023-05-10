using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
   public virtual event Action<Screen> OnTransitionReady;
   public virtual bool IsUpdate { get; set; }
    
   public virtual void OnEnter()
   {

   }

    public virtual void OnExit()
    {

    }
}
