﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WCFTransactionDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void UploadData()
        {
            string strConnection = @"Data Source=DESKTOP-MMMMCBT\SQLExpress;Initial Catalog=DemoDB;Integrated Security=True";

            //throw new Exception();
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            SqlCommand objCommand = new SqlCommand("insert into Customer(CustomerName,CustomerCode) values('sss1','sss1')", objConnection);
            objCommand.ExecuteNonQuery();
            objConnection.Close();
        }
        

    }
}

