using System;
using System.Collections.Generic;
using System.Reflection;

namespace HotUI
{
    public class PropertyMapper<TVirtualView, TNativeView> : Dictionary<string, Func<TNativeView, object, bool>>
    {
        private Dictionary<string, PropertyInfo> _properties = new Dictionary<string, PropertyInfo>();
        
        public void UpdateProperties(TNativeView nativeView, TVirtualView virtualView)
        {
            if (virtualView == null)
                return;

            foreach (var entry in this)
            {
                var propertyName = entry.Key;
                var property = typeof(TVirtualView).GetProperty(propertyName);
                var value = property.GetValue(virtualView);
                entry.Value.Invoke(nativeView, value);
            }
        }
        
        public bool UpdateProperty(TNativeView nativeView, string property, object value)
        {
            if (TryGetValue(property, out var updater))
                return updater.Invoke(nativeView, value);

            return false;
        }
    }
}