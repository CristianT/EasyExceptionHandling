﻿using FortuneCookieLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUpExceptionHandling();

            while (true)
            {
                Console.WriteLine("Tell me your name:");
                var name = Console.ReadLine();

                var fortuneTeller = new FortuneCookie(name);
                var fortune = fortuneTeller.TellMeMyFortune();

                Console.WriteLine(fortune);
            }

            Console.WriteLine("Press a key to exit...");
            Console.ReadLine();
        }

        private static void SetUpExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
            {
                Console.WriteLine("I predict bad fortune during the next seconds...");
                Console.ReadLine();

                Environment.FailFast("Unable to recover from such bad luck!");
            };
        }
    }
}
