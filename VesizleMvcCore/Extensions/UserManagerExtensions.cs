using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.Entities;
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<IDataResult<IdentityResult>> FavoriteAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, Favorite favorite)
        {
            IDataResult<IdentityResult> result;
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.Favorites)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);
            var userFav = user.Favorites.FirstOrDefault(fav => fav.MovieId == favorite.MovieId);

            if (userFav == null)
            {
                user.Favorites.Add(favorite);
                result = new SuccessDataResult<IdentityResult>(Messages.AddFavoriteSuccess, await userManager.UpdateAsync(user));
            }
            else
            {
                user.Favorites.Remove(userFav);
                result = new SuccessDataResult<IdentityResult>(Messages.AddFavoriteSuccess, await userManager.UpdateAsync(user));
            }

            return result;
        }
        public static async Task<IDataResult<IdentityResult>> WatchListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, WatchList watchList)
        {
            IDataResult<IdentityResult> result;
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.WatchLists)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);
            var userWatch = user.WatchLists.FirstOrDefault(watch => watch.MovieId == watchList.MovieId);
            if (userWatch==null)
            {
                user.WatchLists.Add(watchList);
                result = new SuccessDataResult<IdentityResult>(Messages.AddWatchListSuccess, await userManager.UpdateAsync(user));

            }
            else
            {
                user.WatchLists.Remove(userWatch);
                result = new SuccessDataResult<IdentityResult>(Messages.RemoveWatchListSuccess, await userManager.UpdateAsync(user));
            }

            return result;
        }
        public static async Task<IDataResult<IdentityResult>> WatchedListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, WatchedList watchedList)
        {
            IDataResult<IdentityResult> result;
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.WatchedLists)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);

            var userWatched = user.WatchedLists.FirstOrDefault(watch => watch.MovieId == watchedList.MovieId);
            if (userWatched == null)
            {
                user.WatchedLists.Add(watchedList);
                result = new SuccessDataResult<IdentityResult>(Messages.AddWatchedListSuccess, await userManager.UpdateAsync(user));

            }
            else
            {
                user.WatchedLists.Remove(userWatched);
                result = new SuccessDataResult<IdentityResult>(Messages.RemoveWatchedListSuccess, await userManager.UpdateAsync(user));
            }

            return result;
        }
        public static async Task<IdentityResult> ReminderAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, Reminder reminder)
        {
            IdentityResult result;
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.Reminders)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);
            var userReminder = user.Reminders.FirstOrDefault(rem => rem.MovieId == reminder.MovieId);
            if (userReminder == null)
            {
                user.Reminders.Add(reminder);
                result = await userManager.UpdateAsync(user);
            }
            else
            {
                user.Reminders.Remove(userReminder);
                result = await userManager.UpdateAsync(user);
            }

            return result;
        }
        public static Task<VesizleUser> GetUserByAllAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userManager.Users.Include(vesizleUser => vesizleUser.Favorites).Include(vesizleUser => vesizleUser.WatchLists).Include(vesizleUser => vesizleUser.WatchedLists).Include(vesizleUser => vesizleUser.Reminders)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);
        }
        public static Task<ICollection<WatchList>> GetWatchListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userManager.Users.Include(vesizleUser => vesizleUser.WatchLists).Select(user => user.WatchLists)
                .FirstOrDefaultAsync(lists => lists.FirstOrDefault(watched => watched.UserId == userId) != null); ;
        }
        public static Task<ICollection<WatchedList>> GetWatchedListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userManager.Users.Include(vesizleUser => vesizleUser.WatchedLists).Select(user => user.WatchedLists)
                .FirstOrDefaultAsync(lists => lists.FirstOrDefault(watch => watch.UserId == userId) != null);
        }
        public static Task<ICollection<Favorite>> GetFavoritesAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userManager.Users.Include(vesizleUser => vesizleUser.Favorites).Select(user => user.Favorites)
                .FirstOrDefaultAsync(lists => lists.FirstOrDefault(favorite => favorite.UserId == userId) != null); ;
        }
        public static Task<ICollection<Reminder>> GetRemindersAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userManager.Users.Include(vesizleUser => vesizleUser.Reminders).Select(user => user.Reminders)
                .FirstOrDefaultAsync(lists => lists.FirstOrDefault(reminder => reminder.UserId == userId) != null); ;
        }


        public static async Task<bool> IsFavoriteAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, int movieId)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.Favorites)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId); ;
            return user.Favorites.FirstOrDefault(fav => fav.MovieId == movieId) != null;
        }
        public static async Task<bool> IsWatchListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, int movieId)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.WatchLists)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);

            return user.WatchLists.FirstOrDefault(watch => watch.MovieId == movieId) != null;
        }
        public static async Task<bool> IsWatchedListAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, int movieId)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.WatchedLists)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);

            return user.WatchedLists.FirstOrDefault(watched => watched.MovieId == movieId) != null;
        }
        public static async Task<bool> IsReminderAsync(this UserManager<VesizleUser> userManager, ClaimsPrincipal userClaims, int movieId)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await userManager.Users.Include(vesizleUser => vesizleUser.Reminders)
                .FirstOrDefaultAsync(vesizleUser => vesizleUser.Id == userId);

            return user.Reminders.FirstOrDefault(rem => rem.MovieId == movieId) != null;
        }
    }
}
