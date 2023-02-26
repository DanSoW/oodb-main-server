using Db4objects.Db4o;
using oodb_project.models;

namespace oodb_project.data
{
    /// <summary>
    /// Класс, определяющий тестовые данные для базы данных db4o
    /// </summary>
    public class MockData
    {
        private static IObjectContainer? _db;

        public MockData(IObjectContainer db)
        {
            _db = db;
        }

        /* ----- */
        /* Host Mock */
        public HostModel[] hosts = new[]
        {
            new HostModel("76baa1a3-2477-419c-9b9e-5f00eb5990e2", "host 1", "http://host1.ru", "192.168.09.22", "ubuntu"),
            new HostModel("76baa1a3-2477-419c-9b9e-5f00eb5990e3", "host 2", "http://host2.ru", "192.168.09.23", "windows"),
            new HostModel("76baa1a3-2477-419c-9b9e-5f00eb5990e4", "host 3", "http://host3.ru", "192.168.09.22", "ubuntu"),
            new HostModel("76baa1a3-2477-419c-9b9e-5f00eb5990e5", "host 4", "http://host4.ru", "192.168.11.22", "linux"),
            new HostModel("76baa1a3-2477-419c-9b9e-5f00eb5990e6", "host 5", "http://host5.ru", "192.168.09.22", "ubuntu"),
        };

        public void generateHosts()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in hosts)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        /* ----- */
        /* Admin Mock */
        public AdminModel[] admins = new[]
        {
            new AdminModel("543732c6-bcb5-4504-af78-df2d87b4d131", "aaa@mail.ru"),
            new AdminModel("543732c6-bcb5-4504-af78-df2d87b4d132", "awawh@mail.ru"),
            new AdminModel("543732c6-bcb5-4504-af78-df2d87b4d133", "host@mail.ru"),
            new AdminModel("543732c6-bcb5-4504-af78-df2d87b4d134", "abcdef@mail.ru"),
            new AdminModel("543732c6-bcb5-4504-af78-df2d87b4d135", "ubun@mail.ru"),
        };

        public void generateAdmins()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in admins)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        /* ----- */
        /* Data Sources Mock */
        public DataSourceModel[] dataSources = new[]
        {
            new DataSourceModel("2a864617-80aa-48c9-8010-bf24930abfe5", "app 1", "http://github.com/repository/1"),
            new DataSourceModel("2a864611-80aa-48c9-8010-bf24930abfe5", "app 2", "http://github.com/repository/2"),
            new DataSourceModel("2a864613-80aa-48c9-8010-bf24930abfe5", "app 3", "http://github.com/repository/3"),
            new DataSourceModel("2a864614-80aa-48c9-8010-bf24930abfe5", "app 4", "http://github.com/repository/4"),
            new DataSourceModel("2a864619-80aa-48c9-8010-bf24930abfe5", "app 5", "http://github.com/repository/5"),
        };

        public void generateDataSources()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in dataSources)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        /* ----- */
        /* Services Mock */
        public ServiceModel[] services = new[]
        {
            new ServiceModel
            {
                Id = "79036d6b-466c-4d59-93ba-d1e1c7a6392f",
                DataSourceId = "2a864617-80aa-48c9-8010-bf24930abfe5",
                Name = "Service 1",
                Port = 8080,
                TimeUpdate = 200,
            },
            new ServiceModel
            {
                Id = "fc2e7d45-355e-4d09-8a0d-efd084526a54",
                DataSourceId = "2a864611-80aa-48c9-8010-bf24930abfe5",
                Name = "Service 2",
                Port = 5000,
                TimeUpdate = 200,
            },
            new ServiceModel
            {
                Id = "b4b86e51-eece-4f0b-81b4-1443d2c63ad2",
                DataSourceId = "2a864619-80aa-48c9-8010-bf24930abfe5",
                Name = "Service 3",
                Port = 3000,
                TimeUpdate = 300,
            },
        };

        public void generateServices()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in services)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        /* ----- */
        /* HostsServices Mock */
        public HostServiceModel[] hostsServices = new[]
        {
            new HostServiceModel
            {
                Id = "0f9597f9-f07e-4f4c-a91f-3be668d2db72",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e3",
                ServiceId = "79036d6b-466c-4d59-93ba-d1e1c7a6392f"
            },
            new HostServiceModel
            {
                Id = "0f9593f5-f07e-4f4c-a91f-3be775d2db72",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e6",
                ServiceId = "fc2e7d45-355e-4d09-8a0d-efd084526a54"
            },
            new HostServiceModel
            {
                Id = "0f9597f9-f07e-4f4c-a91f-3be775d2db72",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e5",
                ServiceId = "2a864619-80aa-48c9-8010-bf24930abfe5"
            },
        };

        public void generateHostService()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in hostsServices)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        /* ----- */
        /* HostsServices Mock */
        public MonitorAppModel[] monitorApp = new[]
        {
            new MonitorAppModel
            {
                Id = "bb91dc52-87bb-4ded-ba90-89f2d5050a8f",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e3",
                AdminId = "543732c6-bcb5-4504-af78-df2d87b4d135",
                Name = "Application 1",
                Url = "http://app1"
            },
            new MonitorAppModel
            {
                Id = "bb91dc52-87bb-4ded-ba90-89f2d5050a8j",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e6",
                AdminId = "543732c6-bcb5-4504-af78-df2d87b4d134",
                Name = "Application 2",
                Url = "http://app2"
            },
            new MonitorAppModel
            {
                Id = "bb91dc52-87bb-4ded-ba90-89f2d5050a8e",
                HostId = "76baa1a3-2477-419c-9b9e-5f00eb5990e5",
                AdminId = "543732c6-bcb5-4504-af78-df2d87b4d133",
                Name = "Application 3",
                Url = "http://app3"
            },
        };

        public void generateMonitorApp()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in monitorApp)
            {
                _db.Store(item);
            }
        }
        /* ----- */

        public void generateData()
        {
            if (_db == null)
            {
                return;
            }

            foreach (var item in hosts)
            {
                _db.Store(item);
            }

            foreach (var item in admins)
            {
                _db.Store(item);
            }

            foreach (var item in dataSources)
            {
                _db.Store(item);
            }

            foreach (var item in services)
            {
                _db.Store(item);
            }

            foreach (var item in hostsServices)
            {
                _db.Store(item);
            }

            foreach (var item in monitorApp)
            {
                _db.Store(item);
            }
        }
    }
}
