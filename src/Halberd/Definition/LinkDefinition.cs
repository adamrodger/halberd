namespace Halberd.Definition
{
    using System;

    /// <summary>
    /// Link definition
    /// </summary>
    public class LinkDefinition
    {
        /// <summary>
        /// Link rel
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Route name for getting the href template
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// Function to generate the arguments to apply to the href template
        /// </summary>
        public Func<ILinkResource, dynamic> RouteValues { get; set; }
    }
}
