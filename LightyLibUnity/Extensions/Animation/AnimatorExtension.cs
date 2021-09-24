using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Extensions.Animation
{
    public static class AnimatorExtension
    {
        public static void CrossFadeIfNotAlready(this Animator animator, string stateName, float normalizedTransitionDuration)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)) return;
            animator.CrossFade(stateName, normalizedTransitionDuration);
        }
        public static void PlayIfNotAlready(this Animator animator, string stateName)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)) return;
            animator.Play(stateName);
        }
    }
}
