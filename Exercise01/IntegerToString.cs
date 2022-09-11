    using System;
    using System.Numerics;

    namespace Exercise01
    {
        public class IntegerToString
        {
            private static String ConvertWholeNumber(String Number)
            {
                string word = "";
                try
                {
                    bool beginsZero = false;//tests for 0XX
                    bool isDone = false;//test if already translated
                    BigInteger dblAmt = ((BigInteger)Convert.ToDouble(Number));
                    //if ((dblAmt > 0) && number.StartsWith("0"))
                    if (dblAmt > 0)
                    {//test for zero or digit zero in a nuemric
                        beginsZero = Number.StartsWith("0");

                        int numDigits = Number.Length;
                        int pos = 0;//store digit grouping
                        String place = "";//digit grouping name:hundres,thousand,etc...
                        switch (numDigits)
                        {
                            case 1://ones' range

                                word = "ones";
                                isDone = true;
                                break;
                            case 2://tens' range
                                word = "tens";
                                isDone = true;
                                break;
                            case 3://hundreds' range
                                pos = (numDigits % 3) + 1;
                                place = " Hundred ";
                                break;
                            case 4://thousands' range
                            case 5:
                            case 6:
                                pos = (numDigits % 4) + 1;
                                place = " Thousand ";
                                break;
                            case 7://millions' range
                            case 8:
                            case 9:
                                pos = (numDigits % 7) + 1;
                                place = " Million ";
                                break;
                            case 10://Billions's range
                            case 11:
                            case 12:

                                pos = (numDigits % 10) + 1;
                                place = " Billion ";
                                break;
                            //add extra case options for anything above Billion...
                            default:
                                isDone = true;
                                break;
                        }
                        if (!isDone)
                        {//if transalation is not done, continue...(Recursion comes in now!!)
                            if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                            {
                                try
                                {
                                    word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                                }
                                catch { }
                            }
                            else
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                            }

                            //check for trailing zeros
                            //if (beginsZero) word = " and " + word.Trim();
                        }
                        //ignore digit grouping names
                        if (word.Trim().Equals(place.Trim())) word = "";
                    }
                }
                catch { }
                return word.Trim();
            }





            public  String ConvertToWords(String numb)
            {
                String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
                String endStr = "Only";
                try
                {
                    int decimalPlace = numb.IndexOf(".");
                    if (decimalPlace > 0)
                    {
                        wholeNo = numb.Substring(0, decimalPlace);
                        points = numb.Substring(decimalPlace + 1);
                        if (Convert.ToInt32(points) > 0)
                        {
                            andStr = "and";// just to separate whole numbers from points/cents
                            endStr = "Paisa " + endStr;//Cents
                            pointStr = ConvertDecimals(points);
                        }
                    }
                    val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
                }
                catch { }
                return val;
            }

     

            private static String ConvertDecimals(String number)
            {
                String cd = "", digit = "", engOne = "";
                for (int i = 0; i < number.Length; i++)
                {
                    digit = number[i].ToString();
                    if (digit.Equals("0"))
                    {
                        engOne = "Zero";
                    }
                    else
                    {
                        engOne = "ones";
                    }
                    cd += " " + engOne;
                }
                return cd;
            }
            
        }
    }

