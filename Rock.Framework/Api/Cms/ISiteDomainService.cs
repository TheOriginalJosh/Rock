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

namespace Rock.Api.Cms
{
	[ServiceContract]
    public partial interface ISiteDomainService
    {
		[OperationContract]
        Rock.Models.Cms.SiteDomain GetSiteDomain( string id );

        [OperationContract]
        void UpdateSiteDomain( string id, Rock.Models.Cms.SiteDomain SiteDomain );

        [OperationContract]
        void CreateSiteDomain( Rock.Models.Cms.SiteDomain SiteDomain );

        [OperationContract]
        void DeleteSiteDomain( string id );
    }
}
