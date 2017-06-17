namespace Achiever.Services.Web
{
    using System;

    public interface ICacheService
    {
        T Get<T>(string itemName);

        void Set(string itemName, object data, int durationInSeconds);

        void Remove(string itemName);
    }
}
