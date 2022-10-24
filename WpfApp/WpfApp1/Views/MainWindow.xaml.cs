using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();



        }

        private void Brail_Cb_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}












    /*

        //serial number textbox controller
        public string SerialNumber
        {
            get
            {
                return form.SerialNumber;
            }
            set
            {
                if (SerialNumber != value)
                {
                    form.SerialNumber = value;
                    OnPropertyChange("SerialNumber");
                }
            }
        }

        //WindowsProductID textbox controller
        public string WindowsProductID
        {
            get
            {
                return form.WindowsProductID;
            }
            set
            {
                if (WindowsProductID != value)
                {
                    form.WindowsProductID = value;
                    OnPropertyChange("WindowsProductID");
                }
            }
        }

        //CseName textbox controller
        public string CseName
        {
            get
            {
                return form.CseName;
            }
            set
            {
                if (CseName != value)
                {
                    form.CseName = value;
                    OnPropertyChange("CseName");
                }
            }
        }

        //CseNameIL textbox controller
        public string CseNameIL
        {
            get
            {
                return form.CseNameIL;
            }
            set
            {
                if (CseNameIL != value)
                {
                    form.CseNameIL = value;
                    OnPropertyChange("CseNameIL");
                }
            }
        }

        //service call number textbox controller
        public string ServiceCallNum
        {
            get
            {
                return form.ServiceCallNum;
            }
            set
            {
                if (ServiceCallNum != value)
                {
                    form.ServiceCallNum = value;
                    OnPropertyChange("ServiceCallNum");
                }
            }
        }

        //CustomerName textbox controller
        public string CustomerName
        {
            get
            {
                return form.CustomerName;
            }
            set
            {
                if (CustomerName != value)
                {
                    form.CustomerName = value;
                    OnPropertyChange("CustomerName");
                }
            }
        }


        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^START:controller for the radio button for machine type and Scodix Studio^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new MTrbCommandEx();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }



        class MTrbCommandEx : ICommand
        {
            public String MachineType;

            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }



            public void Execute(object parameter)
            {

                switch (parameter)
                {
                    case 1:
                        MachineType = "Ultra101";
                        MessageBox.Show("Unknown Type In Radio Box");
                        break;
                    case 2:
                        MachineType = "UltraPro";
                        break;
                    case 3:
                        MachineType = "UltraProProffesional";
                        break;
                    case 4:
                        MachineType = "Ultra2Pro";
                        break;
                    case 5:
                        MachineType = "Ultra202";
                        break;
                    default:
                        MessageBox.Show("Unknown Type In Radio Box");
                        break;
                }

            }
        }





        #endregion

        class SSrbCommandEx : ICommand
        {

            public String ScodixStudioType;
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }



            public void Execute(object parameter)
            {

                switch (parameter)
                {
                    case 6:
                        ScodixStudioType = "None";
                        break;
                    case 7:
                        ScodixStudioType = "Station";
                        break;
                    case 8:
                        ScodixStudioType = "W2P";
                        break;
                    case 9:
                        ScodixStudioType = "W2P Customize";
                        break;
                    default:
                        MessageBox.Show("Unknown Type In Radio Box");
                        break;
                }

            }


            #endregion
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^END:controller for the radio button for machine type and Scodix Studio^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        //checks checkbox for foiler
        public bool Foiler { get; set; }

        //checks checkbox for Optional Polymer
        public bool OptionalPolymerCB { get; set; }

        //checks checkbox for C&C
        public bool CnC { get; set; }
        //FoilerNumber textbox controller
        public string FoilerNumber
        {
            get
            {
                return form.FoilerNumber;
            }
            set
            {
                if (FoilerNumber != value)
                {
                    form.FoilerNumber = value;
                    OnPropertyChange("FoilerNumber");
                }
            }
        }

        //OptionalPolymer textbox controller
        public string OptionalPolymer
        {
            get
            {
                return form.OptionalPolymer;
            }
            set
            {
                if (OptionalPolymer != value)
                {
                    form.OptionalPolymer = value;
                    OnPropertyChange("OptionalPolymer");
                }
            }
        }

        //checks checkbox's of print mods
        public bool Brail { get; set; }
        public bool Crystal { get; set; }

        //checks Barcode checkbox status
        public bool Barcode { get; set; }



        //check win10 checkbox status
        public bool Win10 { get; set; }


        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^Button Binding command handler and functionality^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        public class CommandHandler : ICommand
        {
            private Action _action;
            private Func<bool> _canExecute;

            /// <summary>
            /// Creates instance of the command handler
            /// </summary>
            /// <param name="action">Action to be executed by the command</param>
            /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
            public CommandHandler(Action action, Func<bool> canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            /// <summary>
            /// Wires CanExecuteChanged event 
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            /// <summary>
            /// Forcess checking if execute is allowed
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                return _canExecute.Invoke();
            }

            public void Execute(object parameter)
            {
                _action();
            }
        }


        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyButtonAction(), () => CanExecuteButton));
            }
        }
        public bool CanExecuteButton
        {
            get
            {
                return true;
            }
        }

        public void MyButtonAction()
        {

        }



    }
}




    */

























