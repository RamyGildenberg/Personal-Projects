using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.ViewModel
{
    
        class TOTP
        {

            private byte[] K;
            public TOTP()
            {
                GenerateKey();
            }
            public void GenerateKey()
            {
                using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
                {
                    /*    Keys SHOULD be of the length of the HMAC output to facilitate
                          interoperability.*/
                    K = new byte[HMACSHA1.Create().HashSize / 8];
                }
            }
            public int HOTP(UInt64 C, int digits = 6)
            {
                var hmac = HMACSHA1.Create();
                hmac.Key = K;
                hmac.ComputeHash(BitConverter.GetBytes(C));
                return Truncate(hmac.Hash, digits);
            }
            public UInt64 CounterNow(int T1 = 30)
            {
                var secondsSinceEpoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                return (UInt64)Math.Floor(secondsSinceEpoch / T1);
            }

            // This presumes that weeks start with Monday.
            // Week 1 is the 1st week of the year with a Thursday in it.
            public UInt64 GetIso8601WeekOfYear(DateTime time)
            {
                // If its Monday, Tuesday or Wednesday, then it'll 
                // be the same week# as whatever Thursday, Friday or Saturday are,
                // and we always get those right
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                {
                    time = time.AddDays(3);
                }

                // Return the week of our adjusted day 
                return GetUint64OfYear(time) + (UInt64)CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }

            public UInt64 GetUint64OfYear(DateTime time)
            {
                return ((UInt64)CultureInfo.InvariantCulture.Calendar.GetYear(time) + 7);
            }



            private int DT(byte[] hmac_result)
            {
                int offset = hmac_result[19] & 0xf;
                int bin_code = (hmac_result[offset] & 0x7f) << 24
                   | (hmac_result[offset + 1] & 0xff) << 16
                   | (hmac_result[offset + 2] & 0xff) << 8
                   | (hmac_result[offset + 3] & 0xff);
                return bin_code;
            }

            private int Truncate(byte[] hmac_result, int digits)
            {
                var Snum = DT(hmac_result);
                return Snum % (int)Math.Pow(10, digits);
            }
        }
    
}