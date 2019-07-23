using System;
using UIKit;

namespace HotUI.iOS.Handlers
{
    public class ProgressBarHandler : AbstractControlHandler<ProgressBar, UIProgressView>
    {
        public static readonly PropertyMapper<ProgressBar> Mapper = new PropertyMapper<ProgressBar>()
        {
            [nameof(ProgressBar.Value)] = MapValueProperty,
            [nameof(ProgressBar.IsIndeterminate)] = MapIsIndeterminateProperty,
        };

        public ProgressBarHandler() : base(Mapper)
        {
        }

        protected override UIProgressView CreateView()
        {
            var progressView = new UIProgressView();
           // progressView. TouchUpInside += HandleTouchUpInside;
           // progressView.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            /*Layer.BorderColor = UIColor.Blue.CGColor;
            Layer.BorderWidth = .5f;
            Layer.CornerRadius = 3f;*/

            return progressView;
        }


        public static void MapValueProperty(IViewHandler viewHandler, ProgressBar virtualView)
        {
         //   var nativeView = (UWPProgressBar)viewHandler.NativeView;
           // nativeView.Value = virtualView.Value;
        }

        public static void MapIsIndeterminateProperty(IViewHandler viewHandler, ProgressBar virtualView)
        {
            //var nativeView = (UWPProgressBar)viewHandler.NativeView;
            //nativeView.IsIndeterminate = virtualView.IsIndeterminate;
        }

        protected override void DisposeView(UIProgressView nativeView)
        {
            throw new NotImplementedException();
        }
    }
}