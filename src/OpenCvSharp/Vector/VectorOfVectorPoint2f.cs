﻿using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class VectorOfVectorPoint2f : DisposableCvObject, IStdVector<Point2f[]>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVectorPoint2f()
        {
            ptr = NativeMethods.vector_vector_Point2f_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public VectorOfVectorPoint2f(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVectorPoint2f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_vector_Point2f_new2(new IntPtr(size));
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_vector_Point2f_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size1
        {
            get
            {
                var res = NativeMethods.vector_vector_Point2f_getSize1(ptr).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size => Size1;

        /// <summary>
        /// vector[i].size()
        /// </summary>
        public IReadOnlyList<long> Size2
        {
            get
            {
                var size1 = Size1;
                var size2Org = new IntPtr[size1];
                NativeMethods.vector_vector_Point2f_getSize2(ptr, size2Org);
                GC.KeepAlive(this);
                var size2 = new long[size1];
                for (var i = 0; i < size1; i++)
                {
                    size2[i] = size2Org[i].ToInt64();
                }
                return size2;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get
            {
                var  res = NativeMethods.vector_vector_Point2f_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Point2f[][] ToArray()
        {
            var size1 = Size1;
            if (size1 == 0)
                return new Point2f[0][];
            var size2 = Size2;

            var ret = new Point2f[size1][];
            for (var i = 0; i < size1; i++)
            {
                ret[i] = new Point2f[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<Point2f>(ret))
            {
                NativeMethods.vector_vector_Point2f_copy(ptr, retPtr);
                GC.KeepAlive(this);
            }
            return ret;
        }
    }
}
