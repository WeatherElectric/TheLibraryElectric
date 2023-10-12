using System;


namespace TheLibraryElectric.Helpers
{
    public static class TimeProxy
    {
        public static int GetMinute()
        {
            return System.DateTime.Now.Minute;
        }
        public static int GetHour()
        {
            return System.DateTime.Now.Hour;
        }
        public static bool IfAfterOrNow(float hour, float minute)
        {
            if(hour*60 + minute <= GetHour()*60 + GetMinute())
            {
                return true;
            }
            return false;
        }
        public static bool IfBeforeOrNow(float hour, float minute)
        {
            if (hour*60 + minute >= GetHour()*60 + GetMinute())
            {
                return true;
            }
            return false;
        }
    }
}
