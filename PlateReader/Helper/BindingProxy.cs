using System.Windows;

namespace PlateReader.Helper
{
    /// <summary>
    /// Feezable proxy class is a helper class for creating bind for the elements that dont have acces to the DataContext. Like a DataGridTextColumn.
    /// Since they are not on the same VisualTree relativesource binding also dont work. 
    /// A propety of Freezable object is that they inherit DataContext even when they no in the visual or logical tree.
    /// </summary>
    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}
