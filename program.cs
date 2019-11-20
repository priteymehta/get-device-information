public static void Main(string[] args)
        {
            try
            {
                string cpuInfo = string.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (cpuInfo == "")
                    {
                        //Get only the first CPU's ID
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                string drive = Path.GetPathRoot(Environment.SystemDirectory);
                string _obj = @"win32_logicaldisk.deviceid=""" + drive.Substring(0, 1).ToString() + @":""";
                ManagementObject dsk = new ManagementObject(_obj);
                dsk.Get();
                string volumeSerial = dsk["VolumeSerialNumber"].ToString();

                Console.WriteLine(cpuInfo + "-" +volumeSerial);
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
