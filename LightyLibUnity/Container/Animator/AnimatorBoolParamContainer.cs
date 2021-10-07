using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Container.Animator
{
    public class AnimatorBoolParamContainer
    {
        public UnityEngine.Animator animator;
        public string paramName;
        protected bool _Value;
        public bool Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                animator.SetBool(paramName, value);
            }
        }

        public AnimatorBoolParamContainer(UnityEngine.Animator animator, string paramName)
        {
            this.animator = animator;
            this.paramName = paramName;
        }
        public bool GetValue()
        {
            Value = animator.GetBool(paramName);
            return Value;
        }
        public void SetValue(bool value)
        {
            Value = value;
        }
    }

    
}
