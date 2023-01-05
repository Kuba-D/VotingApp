namespace VotingApp.Helpers
{
    /// <summary>
    /// Class for encapsulate ConnectionString Options.
    /// </summary>
    public class ConnectionStringOptions
    {
        /// <summary>
        /// The name of the configuration section.
        /// </summary>
        public const string ConnectionStrings = "ConnectionStrings";

        /// <summary>
        /// ConnectionString for ServiceDatabase.
        /// </summary>
        public string ServiceDatabase { get; set; } = string.Empty;
    }
}
