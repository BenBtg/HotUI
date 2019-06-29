using System;
using System.Diagnostics;
using FView = Xamarin.Forms.View;
using HView = HotUI.View;

namespace HotUI.Forms
{
	public class ViewHandler : FView, IFormsView
    {
        private static readonly PropertyMapper<View, ViewHandler> Mapper = new PropertyMapper<View, ViewHandler>()
        {
            [nameof(HotUI.View.Body)] = MapBodyProperty
        };

        private View _view;

        public Action ViewChanged { get; set; }

        public FView View { get; private set; }

        public void Remove(View view)
        {
            _view = null;
            View = null;
        }

        public void SetView(View view)
        {
            _view = view;
            Mapper.UpdateProperties(this, _view);
            ViewChanged?.Invoke();
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }

        public static bool MapBodyProperty(ViewHandler nativeView, object value)
        {
            var virtualView = (View) value;
            var formsView = virtualView?.ToIFormsView();
            if (formsView?.GetType() == typeof(ViewHandler) && virtualView.Body == null)
            {
                // this is recursive.
                Debug.WriteLine($"There is no ViewHandler for {virtualView.GetType()}");
                return true;
            }

            nativeView.View = formsView?.View ?? new Xamarin.Forms.ContentView();
            return true;
        }
    }
}
