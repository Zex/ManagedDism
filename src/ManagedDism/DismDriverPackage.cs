﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ManagedDism
{
    public static partial class DismApi
    {
        /// <summary>
        /// Contains basic information for the driver that is associated with the .inf file.
        /// </summary>
        /// <remarks>
        /// <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/hh824776.aspx"/>
        /// typedef struct DismDriverPackage
        /// {
        ///    PCWSTR PublishedName;
        ///    PCWSTR OriginalFileName;
        ///    BOOL InBox;
        ///    PCWSTR CatalogFile;
        ///    PCWSTR ClassName;
        ///    PCWSTR ClassGuid;
        ///    PCWSTR ClassDescription;
        ///    BOOL BootCritical;
        ///    DismDriverSignature DriverSignature;
        ///    PCWSTR ProviderName;
        ///    SYSTEMTIME Date;
        ///    UINT MajorVersion;
        ///    UINT MinorVersion;
        ///    UINT Build;
        ///    UINT Revision
        /// } DismDriver;
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
        internal struct DismDriverPackage_
        {
            /// <summary>
            /// The published driver name.
            /// </summary>
            public string PublishedName;

            /// <summary>
            /// The original file name of the driver.
            /// </summary>
            public string OriginalFileName;

            /// <summary>
            /// TRUE if the driver is included on the Windows distribution media and automatically installed as part of Windows®, otherwise FALSE.
            /// </summary>
            public bool InBox;

            /// <summary>
            /// The catalog file for the driver.
            /// </summary>
            public string CatalogFile;

            /// <summary>
            /// The class name of the driver.
            /// </summary>
            public string ClassName;

            /// <summary>
            /// The class GUID of the driver.
            /// </summary>
            public string ClassGuid;

            /// <summary>
            /// The class description of the driver.
            /// </summary>
            public string ClassDescription;

            /// <summary>
            /// TRUE if the driver is boot-critical, otherwise FALSE.
            /// </summary>
            public bool BootCritical;

            /// <summary>
            /// The driver signature status.
            /// </summary>
            public DismDriverSignature DriverSignature;

            /// <summary>
            /// The provider of the driver.
            /// </summary>
            public string ProviderName;

            /// <summary>
            /// The manufacturer's build date of the driver.
            /// </summary>
            public SYSTEMTIME Date;

            /// <summary>
            /// The major version number of the driver.
            /// </summary>
            public UInt32 MajorVersion;

            /// <summary>
            /// The minor version number of the driver.
            /// </summary>
            public UInt32 MinorVersion;

            /// <summary>
            /// The build number of the driver.
            /// </summary>
            public UInt32 Build;

            /// <summary>
            /// The revision number of the driver.
            /// </summary>
            public UInt32 Revision;
        }
    }

    /// <summary>
    /// Represents basic information for the driver that is associated with the .inf file.
    /// </summary>
    public sealed class DismDriverPackage
    {
        private readonly DismApi.DismDriverPackage_ _driverPackage;

        /// <summary>
        /// Initializes a new instance of the DismDriverPackage class.
        /// </summary>
        /// <param name="driverPackagePtr">A pointer to a native DismDriverPackage_ struct.</param>
        internal DismDriverPackage(IntPtr driverPackagePtr)
            : this(driverPackagePtr.ToStructure<DismApi.DismDriverPackage_>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the DismDriverPackage class.
        /// </summary>
        /// <param name="driverPackage">A native DismDriverPackage_ struct.</param>
        internal DismDriverPackage(DismApi.DismDriverPackage_ driverPackage)
        {
            _driverPackage = driverPackage;

            // Copy data from the struct
            Version = new Version((int)driverPackage.MajorVersion, (int)driverPackage.MinorVersion, (int)driverPackage.Build, (int)driverPackage.Revision);
        }

        /// <summary>
        /// Gets a value indicating if the driver is boot-critical.
        /// </summary>
        public bool BootCritical
        {
            get
            {
                return _driverPackage.BootCritical;
            }
        }

        /// <summary>
        /// Gets the catalog file for the driver.
        /// </summary>
        public string CatalogFile
        {
            get
            {
                return _driverPackage.CatalogFile;
            }
        }

        /// <summary>
        /// Gets the class description of the driver.
        /// </summary>
        public string ClassDescription
        {
            get
            {
                return _driverPackage.ClassDescription;
            }
        }

        /// <summary>
        /// Gets the class GUID of the driver.
        /// </summary>
        public string ClassGuid
        {
            get
            {
                return _driverPackage.ClassGuid;
            }
        }

        /// <summary>
        /// Gets the class name of the driver.
        /// </summary>
        public string ClassName
        {
            get
            {
                return _driverPackage.ClassName;
            }
        }

        /// <summary>
        /// Gets the manufacturer's build date of the driver.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _driverPackage.Date;
            }
        }

        /// <summary>
        /// Gets the driver signature status.
        /// </summary>
        public DismDriverSignature DriverSignature
        {
            get
            {
                return _driverPackage.DriverSignature;
            }
        }

        /// <summary>
        /// Gets a value indicating if the driver is included on the Windows distribution media and automatically installed as part of Windows®.
        /// </summary>
        public bool InBox
        {
            get
            {
                return _driverPackage.InBox;
            }
        }

        /// <summary>
        /// Gets the original file name of the driver.
        /// </summary>
        public string OriginalFileName
        {
            get
            {
                return _driverPackage.OriginalFileName;
            }
        }

        /// <summary>
        /// Gets the provider of the driver.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return _driverPackage.ProviderName;
            }
        }

        /// <summary>
        /// Gets the published driver name.
        /// </summary>
        public string PublishedName
        {
            get
            {
                return _driverPackage.PublishedName;
            }
        }

        /// <summary>
        /// Gets the major version number of the driver.
        /// </summary>
        public Version Version
        {
            get;
            private set;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as DismDriverPackage);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DismDriverPackage"/> is equal to the current <see cref="DismDriverPackage"/>.
        /// </summary>
        /// <param name="driverPackage">The <see cref="DismDriverPackage"/> object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="DismDriverPackage"/> is equal to the current <see cref="DismDriverPackage"/>; otherwise, false.</returns>
        public bool Equals(DismDriverPackage driverPackage)
        {
            return driverPackage != null
                   && BootCritical == driverPackage.BootCritical
                   && InBox == driverPackage.InBox
                   && CatalogFile == driverPackage.CatalogFile
                   && ClassDescription == driverPackage.ClassDescription
                   && ClassGuid == driverPackage.ClassGuid
                   && ClassName == driverPackage.ClassName
                   && Date == driverPackage.Date
                   && DriverSignature == driverPackage.DriverSignature
                   && OriginalFileName == driverPackage.OriginalFileName
                   && ProviderName == driverPackage.ProviderName
                   && PublishedName == driverPackage.PublishedName;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"/>.</returns>
        public override int GetHashCode()
        {
            return BootCritical.GetHashCode()
                   ^ InBox.GetHashCode()
                   ^ (String.IsNullOrEmpty(CatalogFile) ? 0 : CatalogFile.GetHashCode())
                   ^ (String.IsNullOrEmpty(ClassDescription) ? 0 : ClassDescription.GetHashCode())
                   ^ (String.IsNullOrEmpty(ClassGuid) ? 0 : ClassGuid.GetHashCode())
                   ^ (String.IsNullOrEmpty(ClassName) ? 0 : ClassName.GetHashCode())
                   ^ Date.GetHashCode()
                   ^ DriverSignature.GetHashCode()
                   ^ (String.IsNullOrEmpty(OriginalFileName) ? 0 : OriginalFileName.GetHashCode())
                   ^ (String.IsNullOrEmpty(ProviderName) ? 0 : ProviderName.GetHashCode())
                   ^ (String.IsNullOrEmpty(PublishedName) ? 0 : PublishedName.GetHashCode());
        }
    }

    /// <summary>
    /// Represents a collection of <see cref="DismDriverPackage"/> objects.
    /// </summary>
    public sealed class DismDriverPackageCollection : DismCollection<DismDriverPackage>
    {
        /// <summary>
        /// Initializes a new instance of the TextWriter class.
        /// </summary>
        internal DismDriverPackageCollection()
            : base(new List<DismDriverPackage>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the TextWriter class.
        /// </summary>
        /// <param name="list"></param>
        internal DismDriverPackageCollection(IList<DismDriverPackage> list)
            : base(list)
        {
        }
    }
}