using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MTrbCommandEx = new RelayCommand<object>(GetMachineTypeMethod);
            SSrbCommandEx = new RelayCommand<object>(GetscodixStudioMethod);
            ClickCommand = new RelayCommand(GeneratePasswordMethod);
            //ClickClearCommand = new RelayCommand(ClearMethod);
        }

        //public void ClearMethod(//String serialNumber, String WindowsProductID, String CseName, String CseILName, String ServiceCallNum
        //    //, String CustomerName, String FoilerNumber, String OptionalPolymer,Boolean Foiler, Boolean CnC, Boolean OptionalPolymerCB, Boolean Brail, Boolean Crystal
        //    //, Boolean Barcode, Boolean Win10
        //    )
        //{

        //    //serialNumberTb.Clear() = string.Empty; 
        //    OnPropertyChange("serialNumber");
        //    WindowsProductID = string.Empty;
        //    OnPropertyChange("WindowsProductID");
        //    CseName = string.Empty;
        //    OnPropertyChange("CseName");
        //    CseILName = string.Empty;
        //    OnPropertyChange("CseILName");
        //    ServiceCallNum = string.Empty;
        //    OnPropertyChange("ServiceCallNum");
        //    CustomerName = string.Empty;
        //    OnPropertyChange("CustomerName");
        //    FoilerNumber = string.Empty;
        //    OnPropertyChange("FoilerNumber");
        //    OptionalPolymer = string.Empty;
        //    OnPropertyChange("OptionalPolymer");
        //    Foiler = false;
        //    CnC = false;
        //    OptionalPolymerCB = false;
        //    Brail = false;
        //    Crystal = false;
        //    Barcode = false;
        //    Win10 = false;
        //    MessageBox.Show("asdasdasd");

        //}






        private VersionInfoPassword m_VerInfoPassword = new VersionInfoPassword();
        private void GeneratePasswordMethod()
        {
            string _MachineTypeString = Enum.GetName(typeof(MachineType), _MachineType);
            ulong _MachineTypeUlong = Convert.ToUInt64(EncryptString2int(_MachineTypeString));
            string temp = m_VerInfoPassword.GetMachinePassword(_SerialNumber, _MachineTypeUlong, _WindowsProductID, CnC,
                                       Foiler, Brail, Crystal, Barcode, Win10);
            System.Windows.MessageBox.Show(temp);
            var itemNames = new List<string> { "Serial Number", "CSE Name","SCE IL Name"
                ,"Service Call Number","Customer Name" };
            var checkBoxList = new List<Boolean> { Foiler, OptionalPolymerCB, CnC, Brail, Crystal, Barcode, Win10 };

            List<string> itemList = new List<string>();
            itemList.Add(_SerialNumber);
            itemList.Add(_CseName);
            itemList.Add(_CseILName);
            itemList.Add(_ServiceCallNum);
            itemList.Add(_CustomerName);
            
            var l = NetworkInterface.GetAllNetworkInterfaces();
            var macAddr =// gets the MAC address of the unit
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up && nic.Name.Equals("Etherjet")
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

            macAddr = macAddr.Substring(macAddr.Length - 6);
            //string fileName = @"C\Temp\PasswordGenerator" + DateTime.Now;
            
            

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            

            string _FinlaString = Convert.ToString(GetProductIDLast5Digits());
            string _EnumString = checkBoxChecker(checkBoxList);
            string _ScodixStudioSelection = Convert.ToString(getScodixStudioCode());
            string _MachineTypeSelection= Convert.ToString(getMachineTypeCode());
            string _FoilerNumberString = _FoilerNumber;
            string _PolymerNumberString = _OptionalPolymer;
            _FinlaString = _FinlaString + "-" + _EnumString + "-" + _ScodixStudioSelection + "-" + _MachineTypeSelection;
            


            if (Foiler)
            {
                if(_FoilerNumber != "")
                     _FinlaString += "-" + _FoilerNumber;
            }
            if(OptionalPolymerCB)
            {
                if (_FoilerNumber != "")
                    _FinlaString += "-"+_OptionalPolymer;
            }

            int i = 0, j = 0;
            string outputString = "-";
            for (; i <= itemList.Count - 1; i++, j++)
            {
                outputString += (itemNames[j] + ":" + itemList[i] + ",");
            }
            _FinlaString += outputString.Substring(0, outputString.Length - 1);



            //string str = KeyDecoder.GetWindowsProductKey();
            System.Windows.MessageBox.Show(_FinlaString);

        }

        

        public string GetProductIDLast5Digits()
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
            object productID = windowsNTKey.GetValue("ProductId");

            //string productIDLast5 = productID.ToString().Substring(productID.ToString().Length-5);

            //byte[] productIdByteArray = Encoding.ASCII.GetBytes(Convert.ToString(productID));
            string productIdLast5 = Convert.ToString(productID);
            return productIdLast5.Substring(productIdLast5.Length-5);
            //return DecodeProductKeyWin8AndUp(Encoding.ASCII.GetBytes(productIdByteArray));
            //return EncryptString2int(Convert.ToString(productID));
            //return ulong.Parse(productIDLast5);
        }

        enum formEnums { None = 0, Foiler = 1, OptionalPolymerCB = 2, CnC = 3, Brail = 4, Crystal = 5, Barcode = 6, Win10 = 7 }
        enum MachineType { Ultra101 = 0, UltraPro = 1, UltraProProffesional = 2, Ultra2Pro = 3, Ultra202 = 4 }
        enum ScodixStudio { None = 0, Station = 1, W2P = 2, W2Pcustomize = 3 }
        MachineType _MachineType;
        ScodixStudio _ScodixStudio;
        //formEnums _formEnums = (formEnums)1;
        //int _formEnums1 = (int)formEnums.Foiler;
        public ICommand MTrbCommandEx { get; set; }
        public ICommand SSrbCommandEx { get; set; }
        public ICommand ClickCommand { get; private set; }
        public ICommand ClickClearCommand { get; private set; }
        int getScodixStudioCode()
        {
            switch(_ScodixStudio)
            {
                case ScodixStudio.None:
                    return 0; 
                case ScodixStudio.Station:
                    return 1;     
                case ScodixStudio.W2P:
                    return 2;    
                case ScodixStudio.W2Pcustomize:
                    return 3;   
                default:
                    return 0;
            }
        }
        private void GetscodixStudioMethod(object name)
        {
            switch ((String)name)
            {
                case "6":
                    _ScodixStudio = ScodixStudio.None;
                    break;
                case "7":
                    _ScodixStudio = ScodixStudio.Station;
                    break;
                case "8":
                    _ScodixStudio = ScodixStudio.W2P;
                    break;
                case "9":
                    _ScodixStudio = ScodixStudio.W2Pcustomize;
                    break;
                default:
                    MessageBox.Show("Unknown Type In Radio Box");
                    break;
            }
        }
        int getMachineTypeCode()
        {
            switch (_MachineType)
            {
                case MachineType.Ultra101:
                    return 0;
                case MachineType.UltraPro:
                    return 1;
                case MachineType.UltraProProffesional:
                    return 2;
                case MachineType.Ultra2Pro:
                    return 3;
                case MachineType.Ultra202:
                    return 4;
                default:
                    return 0;
            }
        }

        private void GetMachineTypeMethod(object name)
        {
            switch ((String)name)
            {
                case "1":
                    _MachineType = MachineType.Ultra101;
                    break;
                case "2":
                    _MachineType = MachineType.UltraPro;
                    break;
                case "3":
                    _MachineType = MachineType.UltraProProffesional;
                    break;
                case "4":
                    _MachineType = MachineType.Ultra2Pro;
                    break;
                case "5":
                    _MachineType = MachineType.Ultra202;
                    break;
                default:
                    MessageBox.Show("Unknown Type In Radio Box");
                    break;
            }
        }
        //event handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private String _SerialNumber = string.Empty;
        private String _WindowsProductID = string.Empty;
        private String _CseName = string.Empty;
        private String _CseILName = string.Empty;
        private String _ServiceCallNum = string.Empty;
        private String _CustomerName = string.Empty;
        private String _FoilerNumber = string.Empty;
        private String _OptionalPolymer = string.Empty;



        //serial number textbox controller
        public string serialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                if (_SerialNumber == value)
                {
                    return;
                }
                _SerialNumber = value;
                OnPropertyChange("serialNumber");
            }
        }



        //WindowsProductID textbox controller
        public String WindowsProductID
        {
            get
            {
                return _WindowsProductID;
            }
            set
            {
                if (_WindowsProductID == value)
                {
                    return;
                }
                _WindowsProductID = value;
                OnPropertyChange("WindowsProductID");
            }
        }

        //CseName textbox controller
        public string CseName
        {
            get
            {
                return _CseName;
            }
            set
            {
                if (_CseName == value)
                {
                    return;
                }
                _CseName = value;
                OnPropertyChange("CseName");
            }
        }

        //CseNameIL textbox controller
        public string CseILName
        {
            get
            {
                return _CseILName;
            }
            set
            {
                if (_CseILName == value)
                {
                    return;
                }
                _CseILName = value;
                OnPropertyChange("CseNameIL");
            }
        }

        //service call number textbox controller
        public string ServiceCallNum
        {
            get
            {
                return _ServiceCallNum;
            }
            set
            {
                if (_ServiceCallNum == value)
                {
                    return;
                }
                _ServiceCallNum = value;
                OnPropertyChange("ServiceCallNum");
            }
        }

        //CustomerName textbox controller
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                if (_CustomerName == value)
                {
                    return;
                }
                _CustomerName = value;
                OnPropertyChange("CustomerName");
            }
        }




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
                return _FoilerNumber;
            }
            set
            {
                if (_FoilerNumber == value)
                {
                    return;
                }
                _FoilerNumber = value;
                OnPropertyChange("FoilerNumber");
            }
        }

        //OptionalPolymer textbox controller
        public string OptionalPolymer
        {
            get
            {
                return _OptionalPolymer;
            }
            set
            {
                if (_OptionalPolymer == value)
                {

                }
                _OptionalPolymer = value;
                OnPropertyChange("OptionalPolymer");
            }
        }

        //checks checkbox's of print mods
        public bool Brail { get; set; }
        public bool Crystal { get; set; }

        //checks Barcode checkbox status
        public bool Barcode { get; set; }



        //check win10 checkbox status
        public bool Win10 { get; set; }

        //incription method  






        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public ulong EncryptString2int(string s, int winMajorVer = 10)
        {
            ulong column = 0;
            //OperatingSystem winVer =  System.Environment.OSVersion;
            if (winMajorVer < 10)
            {
                ulong.TryParse(s, out column);
            }
            else
            {

                int iter = 1;
                foreach (char c in s)
                {
                    int index = char.ToUpper(c) - 'A';
                    if (index < 0)
                    {
                        index = 13;
                    }
                    if (iter == 1)
                        column += (uint)index;
                    if (iter > 1)
                        column += 7 * (uint)index;
                    ++iter;
                }
            }
            return column;
        }


        String checkBoxChecker(List<Boolean> lst)
        {
            string enumString = "";
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i])
                    enumString += Convert.ToString(i + 1);//i correspunds to the index of the item in enum collection
                                                          //formEnums, e.g. if Foiler is selected ,its value is true , its index
                                                          //is appended to the string , if not selected , default value is appended
                else
                    enumString += "0";
            }
            return enumString;
        }


        









    }
}













