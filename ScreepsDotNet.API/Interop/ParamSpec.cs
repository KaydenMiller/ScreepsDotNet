﻿using System;
using System.Runtime.InteropServices;

namespace ScreepsDotNet.Interop
{
    public enum InteropValueType : byte
    {
        Void = 0,
        U1 = 1,
        U8 = 2,
        I8 = 3,
        U16 = 4,
        I16 = 5,
        U32 = 6,
        I32 = 7,
        U64 = 8,
        I64 = 9,
        F32 = 10,
        F64 = 11,
        Ptr = 12,
        Str = 13,
        Obj = 14,
        Arr = 15,
    }

    [Flags]
    public enum InteropValueFlags : byte
    {
        None = 0,
        Nullable = 1 << 0,
        NullAsUndefined = 1 << 1,
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
    public struct ParamSpec
    {
        [FieldOffset(0)]
        public InteropValueType Type;
        [FieldOffset(1)]
        public InteropValueFlags Flags;
        [FieldOffset(2)]
        public InteropValueType ElementType;
        [FieldOffset(3)]
        public InteropValueFlags ElementFlags;

        public ParamSpec(InteropValueType type, InteropValueFlags flags)
        {
            Type = type;
            Flags = flags;
            ElementType = InteropValueType.Void;
            ElementFlags = InteropValueFlags.None;
        }

        public ParamSpec(InteropValueType type, InteropValueFlags flags, InteropValueType elementType, InteropValueFlags elementFlags)
        {
            Type = type;
            Flags = flags;
            ElementType = elementType;
            ElementFlags = elementFlags;
        }
    }
}
