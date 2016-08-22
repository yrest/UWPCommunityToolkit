﻿using Windows.UI.Xaml;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    /// <summary>
    /// Represents the control that redistributes space between columns or rows of a Grid control.
    /// </summary>
    public partial class GridSplitter
    {
        /// <summary>
        /// Identifies the <see cref="ResizeDirection"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ResizeDirectionProperty
            = DependencyProperty.Register(
                                            nameof(ResizeDirection),
                                            typeof(GridResizeDirection),
                                            typeof(GridSplitter),
                                            new PropertyMetadata(GridResizeDirection.Auto, OnResizeDirectionChange));

        /// <summary>
        /// Identifies the <see cref="ResizeBehavior"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ResizeBehaviorProperty
            = DependencyProperty.Register(
                                            nameof(ResizeBehavior),
                                            typeof(GridResizeBehavior),
                                            typeof(GridSplitter),
                                            new PropertyMetadata(GridResizeBehavior.BasedOnAlignment, OnResizeBehaviorChange));

        /// <summary>
        /// Gets or sets whether the Splitter resizes the Columns, Rows, or Both.
        /// </summary>
        public GridResizeDirection ResizeDirection
        {
            get { return (GridResizeDirection)GetValue(ResizeDirectionProperty); }

            set { SetValue(ResizeDirectionProperty, value); }
        }

        /// <summary>
        /// Gets or sets which Columns or Rows the Splitter resizes.
        /// </summary>
        public GridResizeBehavior ResizeBehavior
        {
            get { return (GridResizeBehavior)GetValue(ResizeBehaviorProperty); }

            set { SetValue(ResizeBehaviorProperty, value); }
        }

        private static void OnResizeDirectionChange(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var gridSplitter = (GridSplitter)o;
            gridSplitter._resizeDirection = gridSplitter.GetEffectiveResizeDirection();
        }

        private static void OnResizeBehaviorChange(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var gridSplitter = (GridSplitter)o;
            gridSplitter._resizeBehavior = gridSplitter.GetEffectiveResizeBehavior();
        }
    }

    /// <summary>
    /// Enum to indicate whether GridSplitter resizes Columns or Rows
    /// </summary>
    public enum GridResizeDirection
    {
        /// <summary>
        /// Determines whether to resize rows or columns based on its Alignment and
        /// width compared to height
        /// </summary>
        Auto,

        /// <summary>
        /// Resize columns when dragging Splitter.
        /// </summary>
        Columns,

        /// <summary>
        /// Resize rows when dragging Splitter.
        /// </summary>
        Rows
    }

    /// <summary>
    /// Enum to indicate what Columns or Rows the GridSplitter resizes
    /// </summary>
    public enum GridResizeBehavior
    {
        /// <summary>
        /// Determine which columns or rows to resize based on its Alignment.
        /// </summary>
        BasedOnAlignment,

        /// <summary>
        /// Resize the current and next Columns or Rows.
        /// </summary>
        CurrentAndNext,

        /// <summary>
        /// Resize the previous and current Columns or Rows.
        /// </summary>
        PreviousAndCurrent
    }
}
