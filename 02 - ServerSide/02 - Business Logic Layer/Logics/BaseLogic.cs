using System;


namespace CarIsYourHome
{
    public class BaseLogic : IDisposable
    {
        protected CarAndHomeEntities DB = new CarAndHomeEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
