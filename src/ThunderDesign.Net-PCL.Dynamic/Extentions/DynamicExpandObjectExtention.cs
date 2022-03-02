using System;
using System.Linq;
using System.Xml.Linq;
using ThunderDesign.Net.Dynamic.Collections;
using ThunderDesign.Net.Dynamic.DataObjects;
using ThunderDesign.Net.Dynamic.Interfaces;

namespace ThunderDesign.Net.Dynamic.Extentions
{
    public static class DynamicExpandObjectExtention
    {
        public static void LoadFromXML(this DynamicExpandObject self, string xml)
        {
            self.LoadFromXML(XElement.Parse(xml));
        }

        public static void LoadFromXML(this DynamicExpandObject self, XElement xElement)
        {
            if (xElement == null)
                return;
            ((System.Collections.IDictionary)self.Properties).Clear();
            Parse(self, xElement);
        }

        private static void Parse(IDynamicExpandObject parent, XElement node)
        {
            if (node.HasElements)
            {
                if (node.Elements(node.Elements().First().Name.LocalName).Count() > 1)
                {
                    IDynamicExpandObjectList<IDynamicExpandObject> dynamicExpandObjectList = new DynamicExpandObjectList<IDynamicExpandObject>();

                    foreach (var elementList in node.Elements())
                    {
                        IDynamicExpandObject dynamicExpandObject = (IDynamicExpandObject)Activator.CreateInstance(parent.GetType());
                        foreach (var element in elementList.Elements())
                        {
                            Parse(dynamicExpandObject, element);
                        }
                        dynamicExpandObjectList.Add(dynamicExpandObject);
                    }
                    IDynamicExpandObject parentExpandObject = (IDynamicExpandObject)Activator.CreateInstance(parent.GetType());
                    AddProperty(parentExpandObject, node.Elements().First().Name.LocalName, dynamicExpandObjectList);

                    AddProperty(parent, node.Name.ToString(), parentExpandObject);
                }
                else
                {
                    IDynamicExpandObject dynamicExpandObject = (IDynamicExpandObject)Activator.CreateInstance(parent.GetType());

                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(dynamicExpandObject, attribute.Name.ToString(), attribute.Value.Trim());
                    }

                    foreach (var element in node.Elements())
                    {
                        Parse(dynamicExpandObject, element);
                    }

                    AddProperty(parent, node.Name.ToString(), dynamicExpandObject);
                }
            }
            else
            {
                AddProperty(parent, node.Name.ToString(), node.Value.Trim());
            }
        }

        private static void AddProperty(IDynamicExpandObject parent, string name, object value)
        {
            if (parent == null || string.IsNullOrEmpty(name))
                return;

            IDynamicProperty dynamicProperty = new DynamicProperty(name) { Value = value };
            parent.Properties.Add(dynamicProperty);
        }

    }
}
