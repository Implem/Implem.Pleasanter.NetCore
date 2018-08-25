﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.General;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
namespace Implem.Pleasanter.Models
{
    public static class BinaryValidators
    {
        public static Error.Types OnGetting(SiteSettings ss)
        {
            if (!ss.CanRead())
            {
                return Error.Types.HasNotPermission;
            }
            return Error.Types.None;
        }

        public static Error.Types OnUpdating(SiteSettings ss)
        {
            if (!ss.CanManageSite())
            {
                return Error.Types.HasNotPermission;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static Error.Types OnUploadingSiteImage(SiteSettings ss, byte[] file)
        {
            if (!ss.CanManageSite())
            {
                return Error.Types.HasNotPermission;
            }
            if (file == null)
            {
                return Error.Types.SelectFile;
            }
            try
            {
                System.Drawing.Image.FromStream(new System.IO.MemoryStream(file));
            }
            catch (System.Exception)
            {
                return Error.Types.IncorrectFileFormat;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static Error.Types OnDeletingSiteImage(SiteSettings ss)
        {
            if (!ss.CanManageSite())
            {
                return Error.Types.HasNotPermission;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static Error.Types OnUploadingImage(ICollection<IFormFile> files)
        {
            if (!Contract.Attachments())
            {
                return Error.Types.BadRequest;
            }
            var newTotalFileSize = files.Sum(x => x.Length);
            if (OverTenantStorageSize(
                BinaryUtilities.UsedTenantStorageSize(),
                newTotalFileSize,
                Contract.TenantStorageSize()))
            {
                return Error.Types.OverTenantStorageSize;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static Error.Types OnDeletingImage(SiteSettings ss, BinaryModel binaryModel)
        {
            if (!ss.CanUpdate())
            {
                return Error.Types.HasNotPermission;
            }
            if (binaryModel.AccessStatus != Databases.AccessStatuses.Selected)
            {
                return Error.Types.NotFound;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static Error.Types OnUploading(
            Column column,
            Libraries.DataTypes.Attachments attachments,
            ICollection<IFormFile> files)
        {
            if (!Contract.Attachments())
            {
                return Error.Types.BadRequest;
            }
            if (OverLimitQuantity(attachments.Count(), files.Count(), column.LimitQuantity))
            {
                return Error.Types.OverLimitQuantity;
            }
            if (OverLimitSize(files, column.LimitSize))
            {
                return Error.Types.OverLimitSize;
            }
            var newTotalFileSize = files.Sum(x => x.Length);
            if (OverTotalLimitSize(
                attachments.Select(x => x.Size.ToLong()).Sum(),
                newTotalFileSize,
                column.TotalLimitSize))
            {
                return Error.Types.OverTotalLimitSize;
            }
            if (OverTenantStorageSize(
                BinaryUtilities.UsedTenantStorageSize(),
                newTotalFileSize,
                Contract.TenantStorageSize()))
            {
                return Error.Types.OverTenantStorageSize;
            }
            return Error.Types.None;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static bool OverLimitQuantity(long fileCount, long newFileCount, int? limit)
        {
            if ((fileCount + newFileCount) > limit) return true;
            return false;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static bool OverLimitSize(ICollection<IFormFile> files, int? limit)
        {
            foreach (var item in files)
            {
                if (item.Length > (long)limit * 1024 * 1024) return true;
            }
            return false;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static bool OverTotalLimitSize(
            long totalFileSize, long newTotalFileSize, int? limit)
        {
            if ((totalFileSize + newTotalFileSize) > (long)limit * 1024 * 1024) return true;
            return false;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static bool OverTenantStorageSize(
            long totalFileSize, long newTotalFileSize, int? limit)
        {
            if (limit != null &&
                (totalFileSize + newTotalFileSize) > (long)limit * 1024 * 1024 * 1024) return true;
            return false;
        }
    }
}
