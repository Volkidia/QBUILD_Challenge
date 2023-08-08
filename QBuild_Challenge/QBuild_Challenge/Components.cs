using System;
using System.Collections.Generic;
using System.Linq;

namespace QBuild_Challenge
{
    public struct Component
    {
        public string parentName, componentName, partNumber, title, type, item, material;
        public int quantity;
        public Component(string parentName, string componentName, string partNumber, string title, string type, string item, string material, int quantity)
        {
            this.parentName = parentName;
            this.componentName = componentName;
            this.partNumber = partNumber;
            this.title = title;
            this.type = type;
            this.item = item;
            this.material = material;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"component {componentName} : parent = {parentName != ""} - part number = {partNumber} - title = {title} - quantity = {quantity}";
        }
    }
    
    public class ComponentDependencies
    {
        public string partName;
        public List<ComponentDependencies> componentsNames;

        public ComponentDependencies(string partName, List<ComponentDependencies> componentsNames)
        {
            this.partName = partName;
            this.componentsNames = componentsNames;
        }
    }

    public class Components
    {
        public List<Component> components = new List<Component>();

        public Components(Component[] components)
        {
            this.components.AddRange(components);
        }

        public List<Component> GetComponentsOfParent(string parentName)
        {
            List<Component> _retList = components.Where(cmpnt => cmpnt.parentName == parentName).ToList();
            Console.WriteLine($"parentName = {parentName} - Result Count = {components.Count}");
            return _retList;
        }

        public Component GetComponent(string componentName)
        {
            return components.Where(cmpnt => cmpnt.componentName == componentName).First();
        }

        public Component GetRootComponents()
        {
            return GetComponentsOfParent("")[0];
        }

        public ComponentDependencies GetDependencies()
        {
            return GetDependencies("VALVE");
        }

        private ComponentDependencies GetDependencies(string componentName)
        {
            List<Component> _lCmpnts = GetComponentsOfParent(componentName);            
            string _name = componentName;
            List<ComponentDependencies> _lDependencies = new List<ComponentDependencies>();
            foreach(Component _cmpnts in _lCmpnts)
            {
                _lDependencies.Add(GetDependencies(_cmpnts.componentName));
            }
            return new ComponentDependencies(_name, _lDependencies);
        }
    }
}
