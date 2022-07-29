namespace Infrastructure
{
    public interface IDataFormatter<TBasic, TFormatted>
    {
        TFormatted Format(TBasic input);

        TBasic Unformat(TFormatted input);
    }
}
