﻿using DAL.DAL.ADO.Repositories;
using DAL.DAL.EF.Interfaces;
using DAL.DAL.EF.Repositories;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        private StorageContext context;

        public ServiceModule(string connection, StorageContext context)
        {
            connectionString = connection;
            this.context = context;
        }

        public override void Load()
        {
            if (context == StorageContext.EF)
                Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            else if (context == StorageContext.ADO)
                Bind<IUnitOfWork>().To<ADOUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }

    public enum StorageContext
    {
        ADO,
        EF
    }
}
