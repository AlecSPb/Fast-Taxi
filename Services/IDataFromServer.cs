namespace Babat_Taxi.Services
{
    public interface IDataFromServer
    {
        dynamic DataBase { get; set; }

        void GetData();
    }
}