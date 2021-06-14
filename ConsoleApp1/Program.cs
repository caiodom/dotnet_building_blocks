using Core.Domain;
using Core.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using Core.Common;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            var Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            
            var baseRepository = new BaseRepository<BaseNameEntity>(Configuration);

            var teste = baseRepository.GetAsync()
                                        .ContinueWith(task => task.Resolving((type) => 
                                                                                       { 
                                                                                          type.ToList()
                                                                                                .ForEach(x => Console.WriteLine(x.Nome)); 
                                                                                       },
                                                                                       (ex)=> {
                                                                                           Console.WriteLine(ex.Message);
                                                                                       }));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
