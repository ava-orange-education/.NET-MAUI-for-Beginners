﻿using AddingMvvm.Helpers;

namespace AddingMvvm
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            var provider = new ServiceCollection().
                ConfigureServices().BuildServiceProvider();

            ServiceProvider = provider;

            return provider;
        }

    }
}