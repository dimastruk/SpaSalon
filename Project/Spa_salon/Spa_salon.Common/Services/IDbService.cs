using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using DAL;

    public interface IDbService
    {
        DataContext Context { get; }
        void SaveChanges();
        void Initialize();
        void Close();
    }

    public class DbService : IDbService
    {
        private static Task _initializeTask;
        private static bool _isInitialized = false;
        public static DataContext _context;

        public DataContext Context
        {
            get
            {
                _initializeTask.Wait();
                return _context;
            }
        }

        static DbService()
        {
            _context = new DataContext();
            _initializeTask = new Task(() =>
            {
                _context.Database.Initialize(true);
            });
        }

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _initializeTask.Start();
            }
        }

        public void SaveChanges()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Close()
        {
            if (Context != null)
            {
                SaveChanges();
                Context.Dispose();
            }
        }
    }
}
