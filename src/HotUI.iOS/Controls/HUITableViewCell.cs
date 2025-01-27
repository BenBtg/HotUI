using UIKit;

namespace HotUI.iOS.Controls
{
    public class HUITableViewCell : UITableViewCell
    {
        private UIView _currentContent;
        private View _currentView;

        public HUITableViewCell(UITableViewCellStyle style, string reuseIdentifier) : base(style, reuseIdentifier)
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (_currentContent == null)
                return;
            
            _currentContent.Frame = ContentView.Bounds;
        }

        public void SetView(View view)
        {
            if (_currentView != null && !_currentView.IsDisposed)
            {
                view = view.Diff(_currentView);
            }
            _currentView?.Dispose();
            _currentView = view;
            var newView = view.ToView();
            if (_currentContent != newView)
                _currentContent?.RemoveFromSuperview();
            _currentContent = newView;
            if (_currentContent.Superview != ContentView)
                ContentView.Add(_currentContent);
        }
    }
}