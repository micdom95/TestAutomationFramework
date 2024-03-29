﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Automation_Logic.Setup.SecretsConfiguration
{
    public sealed class SecretsConfiguration
    {
        private static volatile SecretsConfiguration _instance;
        private static object _syncRoot = new object();
        private IConfiguration _configuration;

        private SecretsConfiguration()
        {
        }

        public static SecretsConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SecretsConfiguration();
                    }
                }

                return _instance;
            }
        }

        public string DefaultLogInUrl
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("Url:DefaultLogInUrl");
            }
        }

        public string UserNameLoginEmail
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("General:UserNameLoginEmail");
            }
        }

        public string UserLoginPassword
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("General:UserLoginPassword");
            }
        }

        public string UserAlbumNumber
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("General:UserAlbumNumber");
            }
        }

        public string UsernameInfo
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("General:UsernameInfo");
            }
        }

        public string LogsDbConnectionString
        {
            get
            {
                if (_configuration == null)
                {
                    SetupConfiguration();
                }

                return _configuration.GetValue<string>("General:ConnectionString");
            }
        }

        public string DbConnectionString()
        {
            string connectionStringToDb = this._configuration.GetConnectionString("ConnectionString");
            return connectionStringToDb;
        }
        
        private void SetupConfiguration()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = @"\..\..\..\..\Automation Logic\Setup\SecretsConfiguration\SecretsConfiguration.json";
            string fullFilePath = Path.GetFullPath(currentDirectory + file);
            _configuration = new ConfigurationBuilder().AddJsonFile(fullFilePath).Build();  
        }

        private void SetupConfigurationFromDefaultDestination()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SecretsAppSettings.json");
            _configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
        }
    }
}
