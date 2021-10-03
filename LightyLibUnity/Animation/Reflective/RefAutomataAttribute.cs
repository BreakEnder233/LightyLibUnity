using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Animation.Reflective
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class RefAutomataAttribute : Attribute
    {
        public string stateName;
        public RefAutomataAttribute(string stateName)
        {
            this.stateName = stateName;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RefAutomataUpdateAttribute : RefAutomataAttribute
    {
        public RefAutomataUpdateAttribute(string stateName) : base(stateName)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RefAutomataEntryAttribute : RefAutomataAttribute
    {
        public RefAutomataEntryAttribute(string stateName) : base(stateName)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RefAutomataTransferAttribute : RefAutomataAttribute
    {
        public RefAutomataTransferAttribute(string stateName) : base(stateName)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RefAutomataExitAttribute : RefAutomataAttribute
    {
        public RefAutomataExitAttribute(string stateName) : base(stateName)
        {

        }
    }
}
