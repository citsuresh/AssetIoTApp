namespace AssetIoTApp.Models
{
    /// <summary>
    /// AssetCount For Client.
    /// </summary>
    public class AssetCountForClient
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientID { get; set; }

        /// <summary>
        /// Gets or sets the asset count.
        /// </summary>
        /// <value>
        /// The asset count.
        /// </value>
        public int AssetCount { get; set; }
    }
}
