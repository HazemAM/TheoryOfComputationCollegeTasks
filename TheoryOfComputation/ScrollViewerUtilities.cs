﻿using System.Windows;
using System.Windows.Controls;

/*
 * Source: https://marlongrech.wordpress.com/2009/09/14/how-to-set-wpf-scrollviewer-verticaloffset-and-horizontal-offset/
 */
namespace TheoryOfComputation
{
    public class ScrollViewerUtilities
    {
        #region HorizontalOffset

        /// <summary>
        /// HorizontalOffset Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.RegisterAttached("HorizontalOffset", typeof(double), typeof(ScrollViewerUtilities),
                new FrameworkPropertyMetadata((double)0.0,
                    new PropertyChangedCallback(OnHorizontalOffsetChanged)));

        /// <summary>
        /// Gets the HorizontalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static double GetHorizontalOffset(DependencyObject d)
        {
            return (double)d.GetValue(HorizontalOffsetProperty);
        }

        /// <summary>
        /// Sets the HorizontalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetHorizontalOffset(DependencyObject d, double value)
        {
            d.SetValue(HorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Handles changes to the HorizontalOffset property.
        /// </summary>
        private static void OnHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = (ScrollViewer)d;
            viewer.ScrollToHorizontalOffset((double)e.NewValue);
        }

        #endregion

        #region VerticalOffset

        /// <summary>
        /// VerticalOffset Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.RegisterAttached("VerticalOffset", typeof(double), typeof(ScrollViewerUtilities),
                new FrameworkPropertyMetadata((double)0.0,
                    new PropertyChangedCallback(OnVerticalOffsetChanged)));

        /// <summary>
        /// Gets the VerticalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static double GetVerticalOffset(DependencyObject d)
        {
            return (double)d.GetValue(VerticalOffsetProperty);
        }

        /// <summary>
        /// Sets the VerticalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetVerticalOffset(DependencyObject d, double value)
        {
            d.SetValue(VerticalOffsetProperty, value);
        }

        /// <summary>
        /// Handles changes to the VerticalOffset property.
        /// </summary>
        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = (ScrollViewer)d;
            viewer.ScrollToVerticalOffset((double)e.NewValue);
        }

        #endregion
    }
}
