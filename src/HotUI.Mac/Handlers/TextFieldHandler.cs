using System;
using System.Collections.Generic;
using AppKit;
using HotUI.Mac.Extensions;

namespace HotUI.Mac.Handlers
{
    public class TextFieldHandler : NSTextField, INSView
    {
        private static readonly PropertyMapper<TextField, NSTextField> Mapper = new PropertyMapper<TextField, NSTextField>()
        {
            [nameof(TextField.Text)] = MapTextProperty
        };
        
        public TextFieldHandler()
        {
            EditingEnded += EntryHandler_Ended;
        }

        void EntryHandler_Ended(object sender, EventArgs e) => _textField?.Completed(StringValue);

        public NSView View => this;

        public void Remove(View view)
        {
            _textField = null;
        }

        TextField _textField;

        public void SetView(View view)
        {
            _textField = view as TextField;
            Mapper.UpdateProperties(this, _textField);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }
        
        public static bool MapTextProperty(NSTextField nativeView, object value)
        {
            nativeView.StringValue = (string)value;
            nativeView.SizeToFit();
            return true;
        }
    }
}