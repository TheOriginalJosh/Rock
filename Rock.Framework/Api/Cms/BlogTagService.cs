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

namespace Rock.Api.Cms
{
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class BlogTagService : IBlogTagService
    {
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Models.Cms.BlogTag GetBlogTag( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Cms.BlogTagService BlogTagService = new Rock.Services.Cms.BlogTagService();
                Rock.Models.Cms.BlogTag BlogTag = BlogTagService.GetBlogTag( int.Parse( id ) );
                if ( BlogTag.Authorized( "View", currentUser ) )
                    return BlogTag;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateBlogTag( string id, Rock.Models.Cms.BlogTag BlogTag )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlogTagService BlogTagService = new Rock.Services.Cms.BlogTagService();
                Rock.Models.Cms.BlogTag existingBlogTag = BlogTagService.GetBlogTag( int.Parse( id ) );
                if ( existingBlogTag.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingBlogTag).CurrentValues.SetValues(BlogTag);
                    BlogTagService.Save( existingBlogTag, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateBlogTag( Rock.Models.Cms.BlogTag BlogTag )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlogTagService BlogTagService = new Rock.Services.Cms.BlogTagService();
                BlogTagService.AttachBlogTag( BlogTag );
                BlogTagService.Save( BlogTag, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteBlogTag( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlogTagService BlogTagService = new Rock.Services.Cms.BlogTagService();
                Rock.Models.Cms.BlogTag BlogTag = BlogTagService.GetBlogTag( int.Parse( id ) );
                if ( BlogTag.Authorized( "Edit", currentUser ) )
                {
                    BlogTagService.DeleteBlogTag( BlogTag );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
