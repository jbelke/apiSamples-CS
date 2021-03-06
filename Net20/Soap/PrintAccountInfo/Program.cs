﻿using System;
using System.Net;
using dotMailer.PrintAccountInfo.dotMailer;

namespace dotMailer.PrintAccountInfo
{
    class Program
    {
        private const string UserName = "{ Your username here }";
        private const string Password = "{ Your password here }";

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += PrintUnhandledException;

            ApiService client = GetSoapClient();

            ApiAccount account = client.GetCurrentAccountInfo();
            PrintResult(account);
        }

        private static void PrintResult(ApiAccount account)
        {
            Console.WriteLine("Account ID - " + account.Id);
            foreach (ApiAccountProperty property in account.Properties)
            {
                Console.WriteLine("{0} {1} = {2}", property.Type, property.Name, property.Value);
            }
        }

        private static ApiService GetSoapClient()
        {
            ApiService client = new ApiService();
            client.Credentials = new NetworkCredential(UserName, Password);
            return client;
        }

        private static void PrintUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
        }
    }
}
