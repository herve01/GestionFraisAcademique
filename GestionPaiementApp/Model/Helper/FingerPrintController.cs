using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Model.Helper
{
    public class FingerPrintController
    {
        public static DPFP.Capture.Capture Capturer;
        public static DPFP.Processing.Enrollment Enroller;

        public static void InitDevice()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                Enroller = new DPFP.Processing.Enrollment();// Create a capture operation.

                //if (null != Capturer)
                //{
                //    //Capturer.EventHandler = this;
                //    Start();
                //}
            }
            catch (Exception)
            {
                //DeviceFailed = true;
            }
            finally
            {
                //DeviceFailed = true;
            }
        }

        public static void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                }
                catch
                {
                    ////("Can't initiate capture!");
                }
            }
        }

        public static void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                }
            }
        }
    }
}
