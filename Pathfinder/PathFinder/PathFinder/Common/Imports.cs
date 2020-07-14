// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created :
// Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created :
//
// Last Modified By : xenonsmurf Last Modified On : 04-04-2020 Last Modified On : 04-12-2020 Last
// Last Modified On : 07-13-2020 ***********************************************************************
// <copyright file="cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace PathFinder.Common
{
    public class FFXINAV : IDisposable
    {
        [DllImport("FFXINAV.dll", EntryPoint = "CreateTestClass", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr CreateTestClass();

        [DllImport("FFXINAV.dll", EntryPoint = "DisposeTestClass", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void DisposeTestClass(IntPtr pFFXINavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "CanSeeDestination", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool CanSeeDestination(IntPtr pFFXINavClassObject, position_t start, position_t end);

        public string oldString = string.Empty;

        [DllImport("FFXINAV.dll", EntryPoint = "FindRandomPath", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool FindRandomPath(IntPtr pFFXINavClassObject, position_t start, float maxRadius, sbyte maxTurns, bool UseCustom);

        [DllImport("FFXINAV.dll", EntryPoint = "unload", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void unload(IntPtr pFFXINavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "Initialize", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool initialize(IntPtr pFFXINavClassObject, string LogFileName);

        [DllImport("FFXINAV.dll", EntryPoint = "load", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool load(IntPtr pFFXINavClassObject, string path);

        [DllImport("FFXINAV.dll", EntryPoint = "LoadOBJFile", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool LoadOBJFile(IntPtr pFFXINavClassObject, string path);

        [DllImport("FFXINAV.dll", EntryPoint = "DumpNavMesh", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool DumpNavMesh(IntPtr pFFXINavClassObject, string path);

        [DllImport("FFXINAV.dll", EntryPoint = "GetLogMessage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string getLogMessage(IntPtr pFFXINavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "FindPath", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void findPath(IntPtr pFFXINavClassObject, position_t start, position_t end, bool UseCustomNavMesh);

        [DllImport("FFXINAV.dll", EntryPoint = "FindClosestPath", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void FindClosestPath(IntPtr pFFXINavClassObject, position_t start, position_t end, bool UseCustomNavMesh);

        [DllImport("FFXINAV.dll", EntryPoint = "GetDistanceToWall", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern double GetDistanceToWall(IntPtr pFFXINavClassObject, position_t start);

        [DllImport("FFXINAV.dll", EntryPoint = "GetRotation", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern sbyte GetRotation(IntPtr pFFXINavClassObject, position_t start, position_t end);

        [DllImport("FFXINAV.dll", EntryPoint = "isNavMeshEnabled", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isNavMeshEnabled(IntPtr pFFXINavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "IsValidPosition", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool IsValidPosition(IntPtr pFFXINavClassObject, position_t start, bool UseCustom);

        [DllImport("FFXINAV.dll", EntryPoint = "Pathpoints", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int pathpoints(IntPtr pFFXINavClassObject);

        [DllImport("FFXINAV.dll", EntryPoint = "NavMeshSettings", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void navMeshSettings(IntPtr pFFXINavClassObject, double CellSize, double CellHeight, double AgentHight, double AgentRadius, double MaxClimb,
         double MaxSlope, double TileSize, double RegionMinSize, double RegionMergeSize, double EdgeMaxLen, double EdgeError, double VertsPP,
         double DetailSampDistance, double DetailMaxError);

        [DllImport("FFXINAV.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern unsafe bool Get_WayPoints(IntPtr pFFXINavClassObject, out ItemsSafeHandle itemsHandle, out ItemsSafeHandle itemsHandle2,
            out double* xitems, out double* zitems, out int itemCount);

        [DllImport("FFXINAV.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe extern bool ReleaseItems(IntPtr pFFXINavClassObject, IntPtr itemsHandle);

        public unsafe ItemsSafeHandle Get_WayPoints_Wrapper(out double* xitems, out double* zitems, out int itemsCount)
        {
            ItemsSafeHandle itemsHandle;
            if (!Get_WayPoints(this.m_pNativeObject, out itemsHandle, out ItemsSafeHandle itemsHandle2, out xitems, out zitems, out itemsCount))
            {
                throw new InvalidOperationException();
            }

            return itemsHandle;
        }

        /// <summary>
        /// Class ItemsSafeHandle. Implements the <see cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        /// </summary>
        /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        public class ItemsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public ItemsSafeHandle()
                : base(true)
            {
            }

            protected override bool ReleaseHandle()
            {
                return true;
            }
        }

        private IntPtr m_pNativeObject;     // Variable to hold the C++ class's this pointer
        public List<position_t> Waypoints { get; set; }

        public FFXINAV()
        {
            // We have to Create an instance of this class through an exported function
            this.m_pNativeObject = CreateTestClass();
            Waypoints = new List<position_t>();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            if (this.m_pNativeObject != IntPtr.Zero)
            {
                // Call the DLL Export to dispose this class
                DisposeTestClass(this.m_pNativeObject);
                this.m_pNativeObject = IntPtr.Zero;
            }

            if (bDisposing)
            {
                // No need to call the finalizer since we've now cleaned up the unmanaged memory
                GC.SuppressFinalize(this);
            }
        }

        ~FFXINAV()
        {
            Dispose(false);
        }

        public bool CanWeSeeDestination(position_t start, position_t end)
        {
            return CanSeeDestination(this.m_pNativeObject, start, end);
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload()
        {
            unload(this.m_pNativeObject);
        }

        /// <summary>
        /// Initializes the specified pathsize.
        /// </summary>
        /// <param name="LogFileName">Name of the log file.</param>
        public void Initialize(string LogFileName)
        {
            initialize(this.m_pNativeObject, LogFileName);
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Load(string file)
        {
            load(this.m_pNativeObject, file);
        }

        /// <summary>
        /// Loads the ob jfile.
        /// </summary>
        /// <param name="file">The file.</param>
        public void LoadOBJfile(string file)
        {
            Thread.Sleep(2000);
            LoadOBJFile(this.m_pNativeObject, file);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [dumping mesh].
        /// </summary>
        /// <value><c>true</c> if [dumping mesh]; otherwise, <c>false</c>.</value>
        public bool DumpingMesh { get; set; } = false;

        /// <summary>
        /// Dumps the nav mesh.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Dump_NavMesh(string file)
        {
            if (DumpingMesh == false)
            {
                DumpingMesh = true;
                if (DumpNavMesh(this.m_pNativeObject, file))
                {
                    DumpingMesh = false;
                }
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetErrorMessage()
        {
            return getLogMessage(this.m_pNativeObject).ToString();
        }

        /// <summary>
        /// Finds the path to posi.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="UseCustonNavMeshes">if set to <c>true</c> [use custon nav meshes].</param>
        public void FindPathToPosi(position_t start, position_t end, bool UseCustonNavMeshes)
        {
            //set false if using DSP Nav files or meshes made with PathFinder & FFXINAV.dll
            //set true if using Meshes made with Noesis map data
            findPath(this.m_pNativeObject, start, end, UseCustonNavMeshes);
        }

        /// <summary>
        /// Finds the closest path.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="UseCustonNavMeshes">if set to <c>true</c> [use custon nav meshes].</param>
        public void findClosestPath(position_t start, position_t end, bool UseCustonNavMeshes)
        {
            //set false if using DSP Nav files or meshes made with PathFinder & FFXINAV.dll
            //set true if using Meshes made with Noesis map data
            FindClosestPath(this.m_pNativeObject, start, end, UseCustonNavMeshes);
        }

        /// <summary>
        /// Determines whether [is nav mesh enabled].
        /// </summary>
        /// <returns><c>true</c> if [is nav mesh enabled]; otherwise, <c>false</c>.</returns>
        public bool IsNavMeshEnabled()
        {
            if (isNavMeshEnabled(this.m_pNativeObject) == false)
            {
                return false;
            }
            if (isNavMeshEnabled(this.m_pNativeObject) == true)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Pathes the count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int PathCount()
        {
            return pathpoints(this.m_pNativeObject);
        }

        public bool findRandomPath(position_t start, float maxRadius, sbyte maxTurns, bool UseCustom)
        {
            return FindRandomPath(this.m_pNativeObject, start, maxRadius, maxTurns, UseCustom);
        }

        /// <summary>
        /// Determines whether [is valid position] [the specified start].
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="UseCustom">if set to <c>true</c> [use custom].</param>
        /// <returns><c>true</c> if [is valid position] [the specified start]; otherwise, <c>false</c>.</returns>
        public bool isValidPosition(position_t start, bool UseCustom)
        {
            return IsValidPosition(this.m_pNativeObject, start, UseCustom);
        }

        /// <summary>
        /// Gets the waypoints.
        /// </summary>
        public unsafe void GetWaypoints()
        {
            Waypoints.Clear();
            if (pathpoints(this.m_pNativeObject) > 0)
            {
                double* xitems;
                double* zitems;
                int itemsCount;

                using (Get_WayPoints_Wrapper(out xitems, out zitems, out itemsCount))
                {
                    for (int i = 0; i < itemsCount; i++)
                    {
                        var position = new position_t { X = (float)xitems[i], Z = (float)zitems[i] };
                        Waypoints.Add(position);
                    }
                }
            }
        }

        /// <summary>
        /// Changes the nav mesh settings.
        /// </summary>
        /// <param name="CellSize">Size of the cell.</param>
        /// <param name="CellHeight">Height of the cell.</param>
        /// <param name="AgentHeight">Height of the agent.</param>
        /// <param name="AgentRadius">The agent radius.</param>
        /// <param name="MaxClimb">The maximum climb.</param>
        /// <param name="MaxSlope">The maximum slope.</param>
        /// <param name="TileSize">Size of the tile.</param>
        /// <param name="RegionMinSize">Minimum size of the region.</param>
        /// <param name="RegionMergeSize">Size of the region merge.</param>
        /// <param name="EdgeMaxLen">Maximum length of the edge.</param>
        /// <param name="EdgeError">The edge error.</param>
        /// <param name="VertsPP">The verts pp.</param>
        /// <param name="DetailSampDistance">The detail samp distance.</param>
        /// <param name="DetailMaxError">The detail maximum error.</param>
        public void ChangeNavMeshSettings(double CellSize, double CellHeight, double AgentHeight, double AgentRadius, double MaxClimb,
         double MaxSlope, double TileSize, double RegionMinSize, double RegionMergeSize, double EdgeMaxLen, double EdgeError, double VertsPP,
         double DetailSampDistance, double DetailMaxError)
        {
            navMeshSettings(this.m_pNativeObject, CellSize, CellHeight, AgentHeight, AgentRadius, MaxClimb, MaxSlope, TileSize,
                RegionMinSize, RegionMergeSize, EdgeMaxLen, EdgeError, VertsPP, DetailSampDistance, DetailMaxError);
        }

        /// <summary>
        /// Converts to single.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float ToSingle(double value)
        {
            return (float)value;
        }

        /// <summary>
        /// Distances to wall.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <returns>System.Double.</returns>
        public double DistanceToWall(position_t start)
        {
            try
            {
                if (start.X != 0 && start.Z != 0)
                {
                    return GetDistanceToWall(this.m_pNativeObject, start);
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// Getrotations the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>System.SByte.</returns>
        public sbyte Getrotation(position_t start, position_t end)
        {
            return GetRotation(this.m_pNativeObject, start, end);
        }
    }
}