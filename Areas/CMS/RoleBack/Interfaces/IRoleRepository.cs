using System.Data;
using Mentoria.Areas.CMS.RoleBack.DTOs;
using Mentoria.Areas.CMS.RoleBack.Entities;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2024
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace Mentoria.Areas.CMS.RoleBack.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> AsQueryable();

        #region Queries
        int Count();

        Role? GetByRoleId(int roleId);

        List<Role?> GetAll();

        List<Role?> GetAllByRoleId(List<int> lstRoleChecked);

        List<Role> GetAllByNameForModal(string textToSearch);

        paginatedRoleDTO GetAllByNamePaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Non-Queries
        bool Add(Role role);

        bool Update(Role role);

        bool DeleteByRoleId(int role);
        #endregion

        #region Methods for DataTable
        DataTable GetAllByRoleIdInDataTable(List<int> lstRoleChecked);

        DataTable GetAllInDataTable();
        #endregion
    }
}
