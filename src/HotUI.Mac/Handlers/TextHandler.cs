using System;
using System.Collections.Generic;
using AppKit;
using HotUI.Mac.Extensions;

namespace HotUI.Mac.Handlers
{
    public class TextHandler : NSTextField, INSView
    {
        private static readonly PropertyMapper<Text, NSTextField> Mapper = new PropertyMapper<Text, NSTextField>()
        {
            [nameof(Text.Value)] = MapValueProperty
        };
        
        public NSView View => this;

        public TextHandler()
        {
            Editable = false;
            Bezeled = false;
            DrawsBackground = false;
            Selectable = false;
        }

        public void Remove(View view)
        {
        }

        private Text _text;
        
        public void SetView(View view)
        {
            _text = view as Text;
            Mapper.UpdateProperties(this, _text);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }
        
        public static bool MapValueProperty(NSTextField nativeView, object value)
        {
            nativeView.StringValue = (string)value;
            nativeView.SizeToFit();
            return true;
        }
    }
}