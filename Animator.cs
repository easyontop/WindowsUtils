using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Windows_Utilities
{
    public class Animator : Window
    {
        static Storyboard StoryBoard = new Storyboard();
        static TimeSpan duration = TimeSpan.FromMilliseconds(500);
        static TimeSpan duration2 = TimeSpan.FromMilliseconds(1000);

        private static IEasingFunction Smooth
        {
            get;
            set;
        }
        = new QuarticEase
        {
            EasingMode = EasingMode.EaseInOut
        };

        public static void Fade(DependencyObject Object)
        {
            DoubleAnimation FadeIn = new DoubleAnimation()
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(FadeIn, Object);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(FadeIn);
            StoryBoard.Begin();
            StoryBoard.Children.Remove(FadeIn);
        }

        public static void FadeOut(DependencyObject Object)
        {
            DoubleAnimation Fade = new DoubleAnimation()
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(Fade, Object);
            Storyboard.SetTargetProperty(Fade, new PropertyPath("Opacity", 1));
            StoryBoard.Children.Add(Fade);
            StoryBoard.Begin();
            StoryBoard.Children.Remove(Fade);
        }

        public static void FadeOut2(DependencyObject Object)
        {
            DoubleAnimation Fade = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = new Duration(duration),
            };
            Storyboard.SetTarget(Fade, Object);
            Storyboard.SetTargetProperty(Fade, new PropertyPath("Opacity", 0));
            StoryBoard.Children.Add(Fade);
            StoryBoard.Begin();
            StoryBoard.Children.Remove(Fade);
        }

        public static void ObjectShift(Duration speed, DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation Animation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = speed,
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(Animation, Object);
            Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
            StoryBoard.Children.Add(Animation);
            StoryBoard.Begin();
            StoryBoard.Children.Remove(Animation);
        }

        public static void FasterObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation Animation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = TimeSpan.FromMilliseconds(750),
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(Animation, Object);
            Storyboard.SetTargetProperty(Animation, new PropertyPath(MarginProperty));
            StoryBoard.Children.Add(Animation);
            StoryBoard.Begin();
            StoryBoard.Children.Remove(Animation);
        }
    }
}
