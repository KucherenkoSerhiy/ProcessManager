namespace ProcessManager.Core.Patterns
{
    public interface IConverter<TS, TD>
    {
        TD Convert(TS value);
        TS ConvertBack(TD value);
    }
}