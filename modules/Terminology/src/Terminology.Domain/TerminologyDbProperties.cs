namespace Terminology;

public static class TerminologyDbProperties
{
    public static string DbTablePrefix { get; set; } = "Terminology";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Terminology";
}
