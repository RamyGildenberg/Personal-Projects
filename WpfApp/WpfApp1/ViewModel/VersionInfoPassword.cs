using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.ViewModel
{
    internal class VersionInfoPassword
    {



        TOTP m_Totp = new TOTP();

        public string GetMachinePassword(string machineName, ulong verType, string productID, bool withCnC, bool useFoiler, bool useBraille, bool useCrystal, bool useBarcode, bool win10)
        {
            int winver = 7;
            if (win10)
            {
                winver = 10;
            }
            ulong ProdactId = EncryptString2int(productID, winver);
            ulong machineNum = 0;
            ulong addCnC = withCnC ? (ulong)10000 : 0;
            ulong foiler = useFoiler ? (ulong)100000 : 0;
            ulong braille = useBraille ? (ulong)1000000 : 0;
            ulong crystal = useCrystal ? (ulong)10000000 : 0;
            ulong barcode = useBarcode ? (ulong)100000000 : 0;
            if (ulong.TryParse(machineName, out machineNum))
            {
                int password = m_Totp.HOTP(machineNum + ProdactId + 1388 * verType + addCnC + foiler + braille + crystal + barcode, 6);
                return password.ToString();
            }

            return "";
        }

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
    }
}


