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

namespace Rock.Api.Groups
{
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class GroupService : IGroupService
    {
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Models.Groups.Group GetGroup( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Groups.GroupService GroupService = new Rock.Services.Groups.GroupService();
                Rock.Models.Groups.Group Group = GroupService.GetGroup( int.Parse( id ) );
                if ( Group.Authorized( "View", currentUser ) )
                    return Group;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateGroup( string id, Rock.Models.Groups.Group Group )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupService GroupService = new Rock.Services.Groups.GroupService();
                Rock.Models.Groups.Group existingGroup = GroupService.GetGroup( int.Parse( id ) );
                if ( existingGroup.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingGroup).CurrentValues.SetValues(Group);
                    GroupService.Save( existingGroup, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateGroup( Rock.Models.Groups.Group Group )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupService GroupService = new Rock.Services.Groups.GroupService();
                GroupService.AttachGroup( Group );
                GroupService.Save( Group, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteGroup( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupService GroupService = new Rock.Services.Groups.GroupService();
                Rock.Models.Groups.Group Group = GroupService.GetGroup( int.Parse( id ) );
                if ( Group.Authorized( "Edit", currentUser ) )
                {
                    GroupService.DeleteGroup( Group );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
