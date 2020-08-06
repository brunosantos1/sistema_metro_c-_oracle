namespace PM.Domain.Types
{
    public enum ActionType
    {
        /// <summary>
        /// A record was created.
        /// </summary>        
        Created,

        /// <summary>
        /// A record was updated.
        /// </summary>
        Updated,

        /// <summary>
        /// An email was sent.
        /// </summary>
        Sent,

        /// <summary>
        /// An user logged in.
        /// </summary>
        Login,

        /// <summary>
        /// A workflow action.
        /// </summary>
        Workflow,

        /// <summary>
        /// A Sap integration action.
        /// </summary>
        Sap
    }
}
