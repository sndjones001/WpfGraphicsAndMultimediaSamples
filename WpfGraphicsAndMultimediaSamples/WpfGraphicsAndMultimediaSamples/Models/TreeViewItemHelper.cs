using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace WpfGraphicsAndMultimediaSamples.Models
{
    public static class TreeViewItemHelper
    {
        private static TreeViewItem CurrentItem;
        private static readonly RoutedEvent UpdateOverItemEvent = EventManager.RegisterRoutedEvent("UpdateOverItem", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TreeViewItemHelper));
        private static readonly DependencyPropertyKey IsMouseDirectlyOverItemKey = DependencyProperty.RegisterAttachedReadOnly("IsMouseDirectlyOverItem", typeof(bool), typeof(TreeViewItemHelper), new FrameworkPropertyMetadata(null, new CoerceValueCallback(CalculateIsMouseDirectlyOverItem)));
        public static readonly DependencyProperty IsMouseDirectlyOverItemProperty = IsMouseDirectlyOverItemKey.DependencyProperty;

        static TreeViewItemHelper()
        {
            EventManager.RegisterClassHandler(typeof(TreeViewItem), UIElement.MouseEnterEvent, new MouseEventHandler(OnMouseTransition), true);
            EventManager.RegisterClassHandler(typeof(TreeViewItem), UIElement.MouseLeaveEvent, new MouseEventHandler(OnMouseTransition), true);
            EventManager.RegisterClassHandler(typeof(TreeViewItem), UpdateOverItemEvent, new RoutedEventHandler(OnUpdateOverItem));
        }
        public static bool GetIsMouseDirectlyOverItem(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseDirectlyOverItemProperty);
        }
        private static object CalculateIsMouseDirectlyOverItem(DependencyObject item, object value)
        {
            return item == CurrentItem;
        }
        private static void OnUpdateOverItem(object sender, RoutedEventArgs e)
        {
            CurrentItem = sender as TreeViewItem;
            CurrentItem.InvalidateProperty(IsMouseDirectlyOverItemProperty);
            e.Handled = true;
        }
        private static void OnMouseTransition(object sender, MouseEventArgs e)
        {
            lock (IsMouseDirectlyOverItemProperty)
            {
                if (CurrentItem != null)
                {
                    DependencyObject oldItem = CurrentItem;
                    CurrentItem = null;
                    oldItem.InvalidateProperty(IsMouseDirectlyOverItemProperty);
                }

                Mouse.DirectlyOver?.RaiseEvent(new RoutedEventArgs(UpdateOverItemEvent));
            }
        }
    }

    public class MouseLeftButtonUp
    {
        public static DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
            typeof(ICommand),
            typeof(MouseLeftButtonUp),
            new UIPropertyMetadata(CommandChanged));

        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                                                typeof(object),
                                                typeof(MouseLeftButtonUp),
                                                new UIPropertyMetadata(null));

        public static void SetCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(CommandProperty, value);
        }

        public static object GetCommand(DependencyObject target, ICommand value)
        {
            return target.GetValue(CommandProperty);
        }

        public static void SetCommandParameter(DependencyObject target, object value)
        {
            target.SetValue(CommandParameterProperty, value);
        }
        public static object GetCommandParameter(DependencyObject target)
        {
            return target.GetValue(CommandParameterProperty);
        }

        private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Control control = target as Control;
            if (control != null)
            {
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    control.MouseLeftButtonUp += OnMouseLeftButtonUp;
                }
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    control.MouseLeftButtonUp -= OnMouseLeftButtonUp;
                }
            }
        }

        private static void OnMouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            ICommand command = (ICommand)control.GetValue(CommandProperty);
            object commandParameter = control.GetValue(CommandParameterProperty);
            command.Execute(commandParameter);
            e.Handled = true;
        }
    }
}
