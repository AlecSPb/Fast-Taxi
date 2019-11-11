namespace Babat_Taxi.Repository
{
    public interface IDataFromServer
    {
        dynamic DataBase { get; set; }

        void GetData();
    }
}