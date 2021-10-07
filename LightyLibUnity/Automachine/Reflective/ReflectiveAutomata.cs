using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LightyLibUnity.Extensions.Container;

namespace LightyLibUnity.Automachine.Reflective
{
    public abstract class ReflectiveAutomata
    {
        public delegate void AutomataMethod();
        public delegate string AutomataTransfer();

        public string CurrentState { get; protected set; }
        public List<string> states;

        public event AutomataMethod allStateUpdate = ()=> { };

        private Dictionary<string, AutomataMethod> updateMethods = new Dictionary<string, AutomataMethod>();

        private Dictionary<string, AutomataMethod> entryMethods = new Dictionary<string, AutomataMethod>();
        private Dictionary<string, AutomataTransfer> transferMethods = new Dictionary<string, AutomataTransfer>();
        private Dictionary<string, AutomataMethod> exitMethods = new Dictionary<string, AutomataMethod>();

        public ReflectiveAutomata(string currentState)
        {
            AssembleAutomata(currentState);
        }

        public void AssembleAutomata(string currentState)
        {
            var type = GetType();
            var methods = type.GetMethods();

            this.CurrentState = currentState;

            updateMethods.Clear();
            entryMethods.Clear();
            transferMethods.Clear();
            exitMethods.Clear();

            foreach (var method in methods)
            {
                var attributes = method.CustomAttributes.ToList();
                foreach(var attribute in attributes)
                {
                    var attributeType = attribute.AttributeType;
                    if (!attributeType.IsSubclassOf(typeof(RefAutomataAttribute))) continue;

                    var stateName = attribute.ConstructorArguments[0].Value as string;

                    if (attributeType == typeof(RefAutomataUpdateAttribute))
                    {
                        updateMethods.Add(stateName, () => method.Invoke(this, new object[] { }));
                    }

                    if (attributeType == typeof(RefAutomataEntryAttribute))
                    {
                        entryMethods.Add(stateName, () => method.Invoke(this, new object[] { }));
                    }

                    if (attributeType == typeof(RefAutomataTransferAttribute))
                    {
                        transferMethods.Add(stateName, () => (string)method.Invoke(this, new object[] { }));
                    }

                    if (attributeType == typeof(RefAutomataExitAttribute))
                    {
                        exitMethods.Add(stateName, () => method.Invoke(this, new object[] { }));
                    }
                }
            }

            entryMethods.GetIfExist(currentState)?.Invoke();
        }

        public void JumpToState(string targetState)
        {
            exitMethods.GetIfExist(CurrentState)?.Invoke();
            CurrentState = targetState;
            entryMethods.GetIfExist(targetState)?.Invoke();
        }

        public void Update()
        {
            allStateUpdate?.Invoke();
            updateMethods.GetIfExist(CurrentState)?.Invoke();
            var transferMethod = transferMethods.GetIfExist(CurrentState);
            if(transferMethod != null)
            {
                var nextState = transferMethod.Invoke();
                if (nextState != CurrentState)
                {
                    JumpToState(nextState);
                }
            }
        }
    }
}
