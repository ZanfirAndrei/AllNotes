using AllNotes.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllNotes.Domain.EF.Users
{
    public class UserStore : UserStoreBase<User,string,IdentityUserClaim<string>,IdentityUserLogin<string>,IdentityUserToken<string>>
                                //UserStoreBase<
                                //            User, IdentityRole, string, IdentityRoleClaim<string>,
                                //            IdentityUserRole<IdentityRole>, IdentityUserLogin<string>,
                                //            IdentityUserToken<string>, IdentityRoleClaim<>
                                //            >

    {
        public UserStore(IdentityErrorDescriber describer) : base(describer)
        {

        }
        public override IQueryable<User> Users => throw new NotImplementedException();

        public override Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public override Task AddToRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public override Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public override Task<IList<User>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Task<bool> IsInRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public override Task RemoveFromRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task AddUserTokenAsync(IdentityUserToken<string> token)
        {
            throw new NotImplementedException();
        }

        //protected override Task<IdentityRole> FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        protected override Task<IdentityUserToken<string>> FindTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<User> FindUserAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IdentityUserLogin<string>> FindUserLoginAsync(string userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IdentityUserLogin<string>> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //protected override Task<IdentityUserRole<string>> FindUserRoleAsync(string userId, string roleId, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        protected override Task RemoveUserTokenAsync(IdentityUserToken<string> token)
        {
            throw new NotImplementedException();
        }
    }

}
