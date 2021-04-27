using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MTC_Mobile.Interface
{
    public class TimeOfUse
    {
        private string sT51;
        private string sT52;
        private string sT53;
        private string mT53;
        private string sT54;
        private string sT55;
        private List<string> intoST51;
        private List<string> intoST52;
        private List<string> intoST53;
        private List<string> intoMT53;
        private List<string[]> intoST54NonRecurrDates;
        private List<string[]> intoST54RecurrDates;
        private List<string[]> intoST54TiersSwitches;
        private List<string> intoST54WeekDaySchedule;
        private List<string> intoST55;
        private List<string> humanST51;
        private List<string> humanST52;
        private List<string> humanST53;
        private List<string> humanMT53;
        private List<string[]> humanST54NonRecurrDates;
        private List<string[]> humanST54RecurrDates;
        private ArrayList humanST54TiersSwitches;
        private List<string> humanST55;

        Parser common = new Parser();

        public TimeOfUse()
        {

        }

        ~TimeOfUse()
        {

        }

        public string ST51
        {
            get
            {
                return sT51;
            }
            set
            {
                sT51 = value;
                humanST51 = new List<string>();
                intoST51 = new List<string>();
                processingDataST51();
            }
        }

        public string ST52
        {
            get
            {
                return sT52;
            }
            set
            {
                sT52 = value;
                humanST52 = new List<string>();
                intoST52 = new List<string>();
                processingDataST52();
            }
        }

        public string ST53
        {
            get
            {
                return sT53;
            }
            set
            {
                sT53 = value;
                humanST53 = new List<string>();
                intoST53 = new List<string>();
                processingDataST53();
            }
        }

        public string ST54
        {
            get
            {
                return sT54;
            }
            set
            {
                sT54 = value;
                intoST54NonRecurrDates = new List<string[]>();
                humanST54NonRecurrDates = new List<string[]>();
                intoST54RecurrDates = new List<string[]>();
                humanST54RecurrDates = new List<string[]>();
                intoST54TiersSwitches = new List<string[]>();
                intoST54WeekDaySchedule = new List<string>();
                intoTablesST54TiersSwitches = new List<string[]>();
                humanST54TiersSwitches = new ArrayList();
                processingDataST54();
            }
        }

        public string ST55
        {
            get
            {
                return sT55;
            }
            set
            {
                sT55 = value;
                intoST55 = new List<string>();
                humanST55 = new List<string>();
                processingDataST55();
            }
        }

        public List<string> intoTableST51
        {
            get
            {
                return intoST51;
            }
            set
            {
                intoST51 = value;
            }
        }

        public List<string> intoTableST52
        {
            get
            {
                return intoST52;
            }
            set
            {
                intoST52 = value;
            }
        }

        public List<string> intoTableST53
        {
            get
            {
                return intoST53;
            }
            set
            {
                intoST53 = value;
            }
        }

        public List<string[]> intoTableST54NonRecurrDates
        {
            get
            {
                return intoST54NonRecurrDates;
            }
            set
            {
                intoST54NonRecurrDates = value;
            }
        }

        public List<string[]> intoTablesST54RecurrDates
        {
            get
            {
                return intoST54RecurrDates;
            }

            set
            {
                intoST54RecurrDates = value;
            }
        }

        public List<string[]> intoTablesST54TiersSwitches
        {
            get
            {
                return intoST54TiersSwitches;
            }

            set
            {
                intoST54TiersSwitches = value;
            }
        }

        public List<string> intoTablesST54WeekDaySchedule
        {
            get
            {
                return intoST54WeekDaySchedule;
            }

            set
            {
                intoST54WeekDaySchedule = value;
            }
        }

        public List<string[]> humanReadableST54NonRecurrDates
        {
            get
            {
                return humanST54NonRecurrDates;
            }

            set
            {
                humanST54NonRecurrDates = value;
            }
        }

        public List<string[]> humanReadableST54RecurrDates
        {
            get
            {
                return humanST54RecurrDates;
            }

            set
            {
                humanST54RecurrDates = value;
            }
        }

        public ArrayList humanReadableST54TiersSwitches
        {
            get
            {
                return humanST54TiersSwitches;
            }

            set
            {
                humanST54TiersSwitches = value;
            }
        }

        public List<string> intoTableST55
        {
            get
            {
                return intoST55;
            }
            set
            {
                intoST55 = value;
            }
        }

        public List<string> humanReadableST51
        {
            get
            {
                return humanST51;
            }
            set
            {
                humanST51 = value;
            }
        }

        public List<string> humanReadableST52
        {
            get
            {
                return humanST52;
            }
            set
            {
                humanST52 = value;
            }
        }

        public List<string> humanReadableST53
        {
            get
            {
                return humanST53;
            }
            set
            {
                humanST53 = value;
            }
        }

        public List<string> humanReadableST55
        {
            get
            {
                return humanST55;
            }
            set
            {
                humanST55 = value;
            }
        }

        public string MT53
        {
            get
            {
                return mT53;
            }

            set
            {
                mT53 = value;
                humanReadableMT53 = new List<string>();
                intoTableMT53 = new List<string>();
                processingDataMT53();
            }
        }

        public List<string> intoTableMT53
        {
            get
            {
                return intoMT53;
            }

            set
            {
                intoMT53 = value;
            }
        }

        public List<string> humanReadableMT53
        {
            get
            {
                return humanMT53;
            }

            set
            {
                humanMT53 = value;
            }
        }

        private void processingDataST51()
        {
            try
            {
                intoST51.Add(sT51.Substring(0, 2));  // TIME_FUNC_FLAG1      [1]
                intoST51.Add(sT51.Substring(3, 2));  // TIME_FUNC_FLAG2      [1]
                intoST51.Add(sT51.Substring(6, 2));  // CALENDAR_FUNC        [1]
                intoST51.Add(sT51.Substring(9, 2));  // NBR_NON_RECURR_DATES [1]
                intoST51.Add(sT51.Substring(12, 2)); // NBR_RECURR_DATES     [1]           
                intoST51.Add(common.get_little_endian(sT51.Substring(15, 5))); // NBR_TIER_SWITCHES [2]
                intoST51.Add(common.get_little_endian(sT51.Substring(21, 5))); // CALENDAR_TBL_SIZE [2]

                humanST51.Add(common.HexadecimalToBinary(intoST51[0]));  // TIME_FUNC_FLAG1      [1]
                humanST51.Add(common.HexadecimalToBinary(intoST51[1]));  // TIME_FUNC_FLAG2      [1]
                humanST51.Add(common.HexadecimalToBinary(intoST51[2]));  // CALENDAR_FUNC        [1]
                humanST51.Add(common.hexToDecimal(intoST51[3]).ToString()); // NBR_NON_RECURR_DATES [1]
                humanST51.Add(common.hexToDecimal(intoST51[4]).ToString()); // NBR_RECURR_DATES     [1]
                byte[] bTierSwitches = common.convertStringToByteArray(intoST51[5]);
                byte[] bCalendarSize = common.convertStringToByteArray(intoST51[6]);
                humanST51.Add(Convert.ToString(common.byteArrayToDecimal(bTierSwitches))); // NBR_TIER_SWITCHES [2]
                humanST51.Add(Convert.ToString(common.byteArrayToDecimal(bCalendarSize))); // CALENDAR_TBL_SIZE [2]
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processingDataST52()
        {
            try
            {
                intoST52.Add(common.get_little_endian(sT52.Substring(0, 11)));// CLOCK_CALENDAR  [4]
                intoST52.Add(sT52.Substring(12, 2));                          // TIME_DATE_QUAL  [1]

                string reverse = common.get_little_endian(intoST52[0]);
                Int32 intEpoch = Convert.ToInt32(common.get_little_endian_val(reverse));
                string[] dates = common.epoch2string(intEpoch);
                humanST52.Add(dates[1]);                             // CLOCK_CALENDAR  [4]
                humanST52.Add(common.HexadecimalToBinary(intoST52[1]));// TIME_DATE_QUAL  [1]
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processingDataST53()
        {
            try
            {
                string std_version = "1";
                string timeZoneFlag = humanST51[1];
                intoST53.Add(common.get_little_endian(sT53.Substring(0, 11)));  // DST_TIME_EFF  [4]
                intoST53.Add(sT53.Substring(12, 2));                            // DST_TIME_AMT  [1]

                if (timeZoneFlag.Substring(4, 1).Equals("1"))                     // TIME_ZONE_OFFSET[2]
                {
                    intoST53.Add(common.get_little_endian(sT53.Substring(15, 5)));
                }
                else
                {
                    intoST53.Add("00 00");
                }

                if (Convert.ToInt16(std_version) > 1)  // STD_TIME_EFF[4]
                {
                    intoST53.Add(common.get_little_endian(sT53.Substring(21, 11)));
                }
                else
                {
                    intoST53.Add("00 00");
                }

                string reverse = common.get_little_endian(intoST53[0]);
                humanST53.Add(common.get_little_endian_val(reverse));  // DST_TIME_EFF  [4]
                humanST53.Add(common.get_little_endian_val(intoST53[1])); // DST_TIME_AMT  [1]
                string time_zone = common.get_little_endian(intoST53[2]);
                humanST53.Add(common.get_offset_time_zone(time_zone));  // TIME_ZONE_OFFSET  [2]
                string daylight = common.get_little_endian(intoST53[3]);
                humanST53.Add(common.get_little_endian_val(daylight));  // STD_TIME_EFF [4]
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processingDataST54()
        {
            try
            {
                int length_recurr = 0;
                int length_non_date = 0;
                /// Non Recurrent Dates
                int non_recurr_date = Convert.ToInt16(humanST51[3]);
                if (non_recurr_date > 0)
                {
                    int number_season = Convert.ToInt16(common.binaryToDecimal(humanST51[2].Substring(0, 4)));
                    length_non_date = 3 * (non_recurr_date * 3);
                    string frame_non_dates = sT54.Substring(6, length_non_date - 1);
                    for (int l = 0; frame_non_dates.Length > l; l += 9)
                    {
                        string[] row_non = new string[2];
                        row_non[0] = frame_non_dates.Substring(l, 5);
                        row_non[1] = frame_non_dates.Substring(l + 6, 2);
                        intoST54NonRecurrDates.Add(row_non);
                    }
                }
                // human recurrent dates
                foreach (string[] temp in intoST54NonRecurrDates)
                {
                    string[] row_non = new string[7];
                    string reverseDate = common.get_little_endian(temp[0]);
                    string date = common.HexadecimalToBinary(reverseDate.Replace(" ", ""));
                    row_non[0] = common.binaryToDecimal(date.Substring(9, 7)); // year
                    row_non[1] = common.binaryToDecimal(date.Substring(5, 4)); // month
                    row_non[2] = common.binaryToDecimal(date.Substring(0, 5)); // day

                    string reverseAction = common.get_little_endian(temp[1]);
                    string action = common.HexadecimalToBinary(reverseAction.Replace(" ", ""));
                    row_non[3] = common.binaryToDecimal(action.Substring(3, 5)); // Calendar control
                    row_non[4] = common.binaryToDecimal(action.Substring(2, 1)); // Reset Flag
                    row_non[5] = common.binaryToDecimal(action.Substring(1, 1)); // Self read flag
                    row_non[6] = common.binaryToDecimal(action.Substring(0, 1)); // filler
                    humanST54NonRecurrDates.Add(row_non);
                }
                /// Recurrent Dates
                int recurr_dates = Convert.ToInt16(humanST51[4]);
                if (recurr_dates > 0)
                {
                    length_recurr = 3 * (recurr_dates * 3);
                    length_non_date = 3 * (non_recurr_date * 3);
                    string frame_recurr_dates = sT54.Substring(6 + length_non_date, length_recurr - 1);
                    for (int l = 0; frame_recurr_dates.Length > l; l += 9)
                    {
                        string[] row_recurrent = new string[2];
                        row_recurrent[0] = frame_recurr_dates.Substring(l, 5);
                        row_recurrent[1] = frame_recurr_dates.Substring(l + 6, 2);
                        intoST54RecurrDates.Add(row_recurrent);
                    }
                }
                // human recurrent dates
                foreach (string[] temp in intoST54RecurrDates)
                {
                    string[] row_non = new string[8];
                    string reverseDate = common.get_little_endian(temp[0]);
                    string date = common.HexadecimalToBinary(reverseDate.Replace(" ", ""));
                    row_non[0] = common.binaryToDecimal(date.Substring(12, 4)); // Month
                    row_non[1] = common.binaryToDecimal(date.Substring(8, 4));  // offset
                    row_non[2] = common.binaryToDecimal(date.Substring(5, 3));  // WeekDay
                    row_non[3] = common.binaryToDecimal(date.Substring(0, 5));  // Day

                    string reverseAction = common.get_little_endian(temp[1]);
                    string action = common.HexadecimalToBinary(reverseAction.Replace(" ", ""));
                    row_non[4] = common.binaryToDecimal(action.Substring(3, 5)); // Calendar control
                    row_non[5] = common.binaryToDecimal(action.Substring(2, 1)); // Demand reset flag
                    row_non[6] = common.binaryToDecimal(action.Substring(1, 1)); // Self read flag
                    row_non[7] = common.binaryToDecimal(action.Substring(0, 1)); // Filler
                    humanST54RecurrDates.Add(row_non);
                }
                /// Tier Switch
                int tier_switches = Convert.ToInt16(humanST51[5]);
                length_non_date = 3 * (non_recurr_date * 3);
                length_recurr = 3 * (recurr_dates * 3);
                int length_tier_sw = 3 * (tier_switches * 3);

                string frame_tier_switches = sT54.Substring(6 + length_non_date + length_recurr, length_tier_sw - 1);
                for (int l = 0; frame_tier_switches.Length > l; l += 9)
                {
                    string[] row_tier = new string[2];
                    row_tier[0] = frame_tier_switches.Substring(l, 5);
                    row_tier[1] = frame_tier_switches.Substring(l + 6, 2);
                    intoTablesST54TiersSwitches.Add(row_tier);
                }
                // Week day schedule
                string weekDay = sT54.Substring(6 + length_non_date + length_recurr + length_tier_sw);
                string[] schedules = weekDay.Split(' ');
                foreach (string sch in schedules)
                {
                    intoTablesST54WeekDaySchedule.Add(sch);
                }
                // human Tier switches
                string[] weekdays = { "Saturday", "Sunday", "Weekday", "Special", };
                int index = 0;
                int season = 0;
                foreach (string schedule in intoTablesST54WeekDaySchedule)
                {
                    List<string[]> lstTiers = new List<string[]>();
                    foreach (string[] values in intoTablesST54TiersSwitches)
                    {
                        if (schedule.Equals(values[1]))
                        {
                            string[] fields = new string[5];
                            string reverse = common.get_little_endian(values[0]);
                            string temp = common.HexadecimalToBinary(reverse.Replace(" ", ""));
                            fields[0] = weekdays[index];      //Day schedule
                            fields[1] = common.getTier(temp.Substring(13, 3)); //New tier
                            fields[2] = common.binaryToDecimal(temp.Substring(0, 5));//Hour
                            fields[3] = common.binaryToDecimal(temp.Substring(5, 6)); //Min
                            fields[4] = season.ToString(); //number of season
                            lstTiers.Add(fields);
                        }
                    }
                    if (index.Equals(3))
                    {
                        index = 0;
                        season++;
                    }
                    else
                    {
                        index++;
                    }
                    humanST54TiersSwitches.Add(lstTiers);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processingDataST55()
        {
            try
            {
                intoST55.Add(common.get_little_endian(sT55.Substring(0, 11))); // CLOCK_CALENDAR  [4]
                intoST55.Add(sT55.Substring(12, 2));  // TIME_DATE_QUAL  [1]
                intoST55.Add(sT55.Substring(15, 5));  // STATUS [2]
                // human
                string reverse = common.get_little_endian(intoST55[0]);
                Int32 intEpoch = Convert.ToInt32(common.get_little_endian_val(reverse));
                string[] dates = common.epoch2string(intEpoch);
                humanST55.Add(dates[0]); // CLOCK_CALENDAR  [4]
                humanST55.Add(dates[1]);
                humanST55.Add(common.HexadecimalToBinary(intoST55[1]));  // TIME_DATE_QUAL  [1]
                humanST55.Add(Convert.ToInt16(common.HexadecimalToBinary(intoST55[2].Substring(0, 2)).Substring(5, 3), 2).ToString());  // CURR_TIER
                humanST55.Add(Convert.ToInt16(common.HexadecimalToBinary(intoST55[2].Substring(0, 2)).Substring(0, 2), 2).ToString());  // TIER_DRIVE ?
                humanST55.Add(Convert.ToInt16(common.HexadecimalToBinary(intoST55[2].Substring(3, 2)).Substring(4, 4), 2).ToString());  // SPECIAL_SCHD_ACTIVE
                humanST55.Add(Convert.ToInt16(common.HexadecimalToBinary(intoST55[2].Substring(3, 2)).Substring(0, 4), 2).ToString());  // SEASON
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void processingDataMT53()
        {
            humanReadableMT53.Add(common.hexadecimalToString(mT53));
        }
    }
}
