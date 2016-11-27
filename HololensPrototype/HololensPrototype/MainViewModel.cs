using System;
using System.Windows;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace HololensPrototype
{
    public class MainViewModel
    {
        public IPrincipal CurrentPrincipal = Thread.CurrentPrincipal;

        public Visibility scenarioButtonVisibility
        {
            get
            {
                if (CurrentPrincipal.IsInRole("Developer"))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            set { }
        }

        public Visibility surveyButtonVisibility
        {
            get
            {
                if (CurrentPrincipal.IsInRole("Developer"))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            set { }
        }

        public Visibility surveyAnswerButtonVisibility
        {
            get
            {
                if (CurrentPrincipal.IsInRole("Developer") ||
                    CurrentPrincipal.IsInRole("Tester") ||
                    CurrentPrincipal.IsInRole("Evaluator"))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            set { }
        }
    }
}
