//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.Api.Util
{
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class JobService : IJobService
    {
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Models.Util.Job GetJob( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Util.JobService JobService = new Rock.Services.Util.JobService();
                Rock.Models.Util.Job Job = JobService.GetJob( int.Parse( id ) );
                if ( Job.Authorized( "View", currentUser ) )
                    return Job;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateJob( string id, Rock.Models.Util.Job Job )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Util.JobService JobService = new Rock.Services.Util.JobService();
                Rock.Models.Util.Job existingJob = JobService.GetJob( int.Parse( id ) );
                if ( existingJob.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingJob).CurrentValues.SetValues(Job);
                    JobService.Save( existingJob, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateJob( Rock.Models.Util.Job Job )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Util.JobService JobService = new Rock.Services.Util.JobService();
                JobService.AttachJob( Job );
                JobService.Save( Job, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteJob( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Util.JobService JobService = new Rock.Services.Util.JobService();
                Rock.Models.Util.Job Job = JobService.GetJob( int.Parse( id ) );
                if ( Job.Authorized( "Edit", currentUser ) )
                {
                    JobService.DeleteJob( Job );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
