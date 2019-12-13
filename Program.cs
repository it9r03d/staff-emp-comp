using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApiDemo {
    public class Program {
        private const string pathToFileDB = "./db/sqldb";
        
//        public static string ToApplicationPath(this string fileName)
//        {
//            var exePath = Path.GetDirectoryName(System.Reflection
//                .Assembly.GetExecutingAssembly().CodeBase);
//            Regex appPathMatcher=new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
//            var appRoot = appPathMatcher.Match(exePath).Value;
//            return Path.Combine(appRoot, fileName);
//        }
        
        public static void Main(string[] args) {
            //https://docs.microsoft.com/ru-ru/ef/core/get-started/?tabs=netcore-cli
            
            //http://zetcode.com/csharp/sqlite/
            // /*
//            Environment.SetEnvironmentVariable("windir", "windir1");
//            string cs = @"URI=file:/home/qa/_dotnet/WebApiDemo/db/sqldb";
//            Console.WriteLine("wdir = " + Environment.GetEnvironmentVariable("windir"));
//            Console.WriteLine("cwd = " + Directory.GetCurrentDirectory());
//            Console.WriteLine("cwd2 = " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
//            Console.WriteLine("cwd3 = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase));
/*
            string pathToFileDB = Directory.GetCurrentDirectory() + '/' + Program.pathToFileDB;
            //            Console.WriteLine("cwd4 = " + pathToFileDB);
            string cs = @"URI=file:"+pathToFileDB;
            //string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            using var con = new SQLiteConnection(cs);
            con.Open();
            
            //**
            stm = "SELECT * FROM emp LIMIT 3";

            using SQLiteDataReader rdr = (new SQLiteCommand(stm, con)).ExecuteReader();

            Console.WriteLine("= = = = = = = =  = = = = = = = =  = = = = = = = =  = = = = = = = =  = = = = = = = =");
            //Console.WriteLine($"{rdr.GetName(0), -3} {rdr.GetName(1), -8} {rdr.GetName(2), 8}");
            //Console.WriteLine( rdr.FieldCount );
            var strFields = $"{rdr.GetName(0), -3} {rdr.GetName(1), -8} {rdr.GetName(2), -12}";
            strFields += $"{rdr.GetName(3), -12} {rdr.GetName(4), -10} {rdr.GetName(5), -16}";
            strFields += $"{rdr.GetName(6), -16}";
            Console.WriteLine( strFields );

            while (rdr.Read()) {
                //Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string surname = rdr.GetString(2);
                string phone = rdr.GetString(3);
                int companyid = rdr.GetInt32(4); // @todo getCompanyName
                string pType = rdr.GetString(5);
                string pNumb = rdr.GetString(6);
                
                Console.WriteLine($"{id, -3} {name, -8} {surname, -12} {phone, -12} {companyid, -10} {pType, -16} {pNumb, -16}");
            }
            Console.WriteLine("= = = = = = = =  = = = = = = = =  = = = = = = = =  = = = = = = = =  = = = = = = = =");
            //**
            
            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");
            // */
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
