using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConWCFMathHost
{
    class Program
    {
        static ServiceHost m_svcHost = null;

        static void Main(string[] args)
        {
            //if (args.Count() != 2)
            //{
            //    Console.WriteLine("Insufficient arguments supplied");
            //    Console.WriteLine("Service Host must be started as <Executable Name> <TCP/HTTP> <Port#>");
            //    Console.WriteLine("Argument 1 >> Specifying the Binding, which binding will be used to Host (Supported values are either HTTP or TCP) without quotes");
            //    Console.WriteLine("Argument 2 >> Port Number a numeric value, the port you want to use");
            //    Console.WriteLine("\nExamples");
            //    Console.WriteLine("<Executable Name> TCP 9001");
            //    Console.WriteLine("<Executable Name> TCP 8001");
            //    Console.WriteLine("<Executable Name> HTTP 8001");
            //    Console.WriteLine("<Executable Name> HTTP 9001");

            //    return;
            //}

            string strBinding = "HTTP";
            bool bSuccess = ((strBinding == "TCP") || (strBinding == "HTTP"));
            if (bSuccess == false)
            {
                Console.WriteLine("\nBinding argument is invalid, should be either TCP or HTTP)");
                return;
            }
            int nPort = 0;
            bSuccess = int.TryParse("9001", out nPort);
            if (bSuccess == false)
            {
                Console.WriteLine("\nPort number must be a numeric value");
                return;
            }

            bool bindingTCP = (strBinding == "TCP");
            if (bindingTCP) StartTCPService(nPort); else StartHTTPService(nPort);
            if (m_svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                StopService();
            }

        }

        private static void StartTCPService(int nPort)
        {
            string strAdr = @"net.tcp://localhost:" + nPort.ToString() + "/MathService/";
            try
            {
                Uri adrbase = new Uri(strAdr);
                m_svcHost = new ServiceHost(typeof(MathService), adrbase);

                ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
                m_svcHost.Description.Behaviors.Add(mBehave);
                m_svcHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                NetTcpBinding tcpb = new NetTcpBinding();
                m_svcHost.AddServiceEndpoint(typeof(MathService), tcpb, strAdr);
                m_svcHost.Open();
                Console.WriteLine("\n\nService is Running as >> " + strAdr);
            }
            catch (Exception eX)
            {
                m_svcHost = null;
                Console.WriteLine("Service can not be started as >> [" + strAdr + "] \n\nError Message [" + eX.Message + "]");
                Console.ReadKey();
            }
        }

        private static void StartHTTPService(int nPort)
        {
            string strAdr = @"http://localhost:9001/MathService";
            try
            {
                Uri adrbase = new Uri(strAdr);
                m_svcHost = new ServiceHost(typeof(MathService), adrbase);

                ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
                m_svcHost.Description.Behaviors.Add(mBehave);
                m_svcHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                BasicHttpBinding httpb = new BasicHttpBinding();
                m_svcHost.AddServiceEndpoint(typeof(MathService), httpb, strAdr);
                m_svcHost.Open();
                Console.WriteLine("\n\nService is Running as >> " + strAdr);
            }
            catch (Exception eX)
            {
                m_svcHost = null;
                Console.WriteLine("Service can not be started as >> [" + strAdr + "] \n\nError Message [" + eX.Message + "]");
            }
        }

        private static void StopService()
        {
            if (m_svcHost != null)
            {
                m_svcHost.Close();
                m_svcHost = null;
            }
        }
    }

    [ServiceContract]
    public class MathService
    {
        [OperationContract]
        public int AddNumber(int dblX, int dblY){
            return dblX + dblY;
        }
        //[OperationContract]
        //double SubtractNumber(double dblX, double dblY);
        //[OperationContract]
        //double MultiplyNumber(double dblX, double dblY);
        //[OperationContract]
        //double DivideNumber(double dblX, double dblY);
    }
}
