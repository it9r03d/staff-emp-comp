using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://docs.microsoft.com/ru-ru/ef/core/get-started/?tabs=netcore-cli
            
            //http://zetcode.com/csharp/sqlite/
            /*
            string cs = @"URI=file:/home/qa/_dotnet/WebApiDemo/db/sqldb";
            //string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            using var con = new SQLiteConnection(cs);
            con.Open();
            
            //**
            stm = "SELECT * FROM emp LIMIT 3";

            using SQLiteDataReader rdr = (new SQLiteCommand(stm, con)).ExecuteReader();

            while (rdr.Read())
            {
                //Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string surname = rdr.GetString(2);
                string phone = rdr.GetString(3);
                int companyid = rdr.GetInt32(4); // @todo getCompanyName
                string pType = rdr.GetString(5);
                string pNumb = rdr.GetString(6);
                
                Console.WriteLine($"{id, -3} {name} {surname} {phone} {companyid} {pType} {pNumb}");
            }
            //**
            
            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");
            */
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}