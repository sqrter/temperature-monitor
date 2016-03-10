#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("GrainInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace GrainInterfaces
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::GrainInterfaces.IProcessor))]
    internal class OrleansCodeGenProcessorReference : global::Orleans.Runtime.GrainReference, global::GrainInterfaces.IProcessor
    {
        protected @OrleansCodeGenProcessorReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenProcessorReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -1962413964;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::GrainInterfaces.IProcessor";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -1962413964;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -1962413964:
                    switch (@methodId)
                    {
                        case 1683511162:
                            return "Init";
                        case -1068425144:
                            return "AddTemperature";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1962413964 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @Init(global::GrainInterfaces.IPrinter @printerGrain)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1683511162, new global::System.Object[]{@printerGrain is global::Orleans.Grain ? @printerGrain.@AsReference<global::GrainInterfaces.IPrinter>() : @printerGrain});
        }

        public global::System.Threading.Tasks.Task @AddTemperature(global::Common.Messages.DeviceTemperature @data)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-1068425144, new global::System.Object[]{@data});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::GrainInterfaces.IProcessor", -1962413964, typeof (global::GrainInterfaces.IProcessor)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenProcessorMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::System.Int32 @interfaceId, global::System.Int32 @methodId, global::System.Object[] @arguments)
        {
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (@interfaceId)
                {
                    case -1962413964:
                        switch (@methodId)
                        {
                            case 1683511162:
                                return ((global::GrainInterfaces.IProcessor)@grain).@Init((global::GrainInterfaces.IPrinter)@arguments[0]).@Box();
                            case -1068425144:
                                return ((global::GrainInterfaces.IProcessor)@grain).@AddTemperature((global::Common.Messages.DeviceTemperature)@arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1962413964 + ",methodId=" + @methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -1962413964;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::Common.Messages.DeviceTemperature)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenCommon_Messages_DeviceTemperatureSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::Common.Messages.DeviceTemperature).@GetField("<DeviceId>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::Common.Messages.DeviceTemperature, global::System.Int64> setField0 = (global::System.Action<global::Common.Messages.DeviceTemperature, global::System.Int64>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        private static readonly global::System.Reflection.FieldInfo field1 = typeof (global::Common.Messages.DeviceTemperature).@GetField("<Value>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::Common.Messages.DeviceTemperature, global::System.Double> setField1 = (global::System.Action<global::Common.Messages.DeviceTemperature, global::System.Double>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field1);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::Common.Messages.DeviceTemperature input = ((global::Common.Messages.DeviceTemperature)original);
            global::Common.Messages.DeviceTemperature result = (global::Common.Messages.DeviceTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.DeviceTemperature));
            setField0(result, input.@DeviceId);
            setField1(result, input.@Value);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::Common.Messages.DeviceTemperature input = (global::Common.Messages.DeviceTemperature)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@DeviceId, stream, typeof (global::System.Int64));
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Value, stream, typeof (global::System.Double));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::Common.Messages.DeviceTemperature result = (global::Common.Messages.DeviceTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.DeviceTemperature));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int64)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int64), stream));
            setField1(result, (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream));
            return (global::Common.Messages.DeviceTemperature)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::Common.Messages.DeviceTemperature), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenCommon_Messages_DeviceTemperatureSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::GrainInterfaces.IDevice))]
    internal class OrleansCodeGenDeviceReference : global::Orleans.Runtime.GrainReference, global::GrainInterfaces.IDevice
    {
        protected @OrleansCodeGenDeviceReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenDeviceReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 1233120812;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::GrainInterfaces.IDevice";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 1233120812;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 1233120812:
                    switch (@methodId)
                    {
                        case -943713836:
                            return "Init";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 1233120812 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @Init(global::GrainInterfaces.IProcessor @processor)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-943713836, new global::System.Object[]{@processor is global::Orleans.Grain ? @processor.@AsReference<global::GrainInterfaces.IProcessor>() : @processor});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::GrainInterfaces.IDevice", 1233120812, typeof (global::GrainInterfaces.IDevice)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenDeviceMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::System.Int32 @interfaceId, global::System.Int32 @methodId, global::System.Object[] @arguments)
        {
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (@interfaceId)
                {
                    case 1233120812:
                        switch (@methodId)
                        {
                            case -943713836:
                                return ((global::GrainInterfaces.IDevice)@grain).@Init((global::GrainInterfaces.IProcessor)@arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + 1233120812 + ",methodId=" + @methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 1233120812;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::GrainInterfaces.IPrinter))]
    internal class OrleansCodeGenPrinterReference : global::Orleans.Runtime.GrainReference, global::GrainInterfaces.IPrinter
    {
        protected @OrleansCodeGenPrinterReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenPrinterReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -1618503141;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::GrainInterfaces.IPrinter";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -1618503141;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -1618503141:
                    switch (@methodId)
                    {
                        case 72318212:
                            return "PrintAverage";
                        case -816558819:
                            return "ThresholdExceeded";
                        case -2006791096:
                            return "ValueNormalized";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1618503141 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @PrintAverage(global::Common.Messages.AverageTemperature @data)
        {
            return base.@InvokeMethodAsync<global::System.Object>(72318212, new global::System.Object[]{@data});
        }

        public global::System.Threading.Tasks.Task @ThresholdExceeded(global::Common.Messages.ThresholdExceeded @msg)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-816558819, new global::System.Object[]{@msg});
        }

        public global::System.Threading.Tasks.Task @ValueNormalized(global::Common.Messages.ValueNormalized @msg)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-2006791096, new global::System.Object[]{@msg});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::GrainInterfaces.IPrinter", -1618503141, typeof (global::GrainInterfaces.IPrinter)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenPrinterMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::System.Int32 @interfaceId, global::System.Int32 @methodId, global::System.Object[] @arguments)
        {
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (@interfaceId)
                {
                    case -1618503141:
                        switch (@methodId)
                        {
                            case 72318212:
                                return ((global::GrainInterfaces.IPrinter)@grain).@PrintAverage((global::Common.Messages.AverageTemperature)@arguments[0]).@Box();
                            case -816558819:
                                return ((global::GrainInterfaces.IPrinter)@grain).@ThresholdExceeded((global::Common.Messages.ThresholdExceeded)@arguments[0]).@Box();
                            case -2006791096:
                                return ((global::GrainInterfaces.IPrinter)@grain).@ValueNormalized((global::Common.Messages.ValueNormalized)@arguments[0]).@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1618503141 + ",methodId=" + @methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -1618503141;
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::Common.Messages.AverageTemperature)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenCommon_Messages_AverageTemperatureSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::Common.Messages.AverageTemperature).@GetField("<Value>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::Common.Messages.AverageTemperature, global::System.Nullable<global::System.Double>> setField0 = (global::System.Action<global::Common.Messages.AverageTemperature, global::System.Nullable<global::System.Double>>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::Common.Messages.AverageTemperature input = ((global::Common.Messages.AverageTemperature)original);
            global::Common.Messages.AverageTemperature result = (global::Common.Messages.AverageTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.AverageTemperature));
            setField0(result, (global::System.Nullable<global::System.Double>)global::Orleans.Serialization.SerializationManager.@DeepCopyInner(input.@Value));
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::Common.Messages.AverageTemperature input = (global::Common.Messages.AverageTemperature)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Value, stream, typeof (global::System.Nullable<global::System.Double>));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::Common.Messages.AverageTemperature result = (global::Common.Messages.AverageTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.AverageTemperature));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Nullable<global::System.Double>)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Nullable<global::System.Double>), stream));
            return (global::Common.Messages.AverageTemperature)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::Common.Messages.AverageTemperature), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenCommon_Messages_AverageTemperatureSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::Common.Messages.ThresholdExceeded)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenCommon_Messages_ThresholdExceededSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::Common.Messages.ThresholdExceeded).@GetField("<DeviceId>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::Common.Messages.ThresholdExceeded, global::System.Int64> setField0 = (global::System.Action<global::Common.Messages.ThresholdExceeded, global::System.Int64>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::Common.Messages.ThresholdExceeded input = ((global::Common.Messages.ThresholdExceeded)original);
            global::Common.Messages.ThresholdExceeded result = (global::Common.Messages.ThresholdExceeded)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.ThresholdExceeded));
            setField0(result, input.@DeviceId);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::Common.Messages.ThresholdExceeded input = (global::Common.Messages.ThresholdExceeded)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@DeviceId, stream, typeof (global::System.Int64));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::Common.Messages.ThresholdExceeded result = (global::Common.Messages.ThresholdExceeded)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.ThresholdExceeded));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int64)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int64), stream));
            return (global::Common.Messages.ThresholdExceeded)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::Common.Messages.ThresholdExceeded), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenCommon_Messages_ThresholdExceededSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.2.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::Common.Messages.ValueNormalized)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenCommon_Messages_ValueNormalizedSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::Common.Messages.ValueNormalized).@GetField("<DeviceId>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::Common.Messages.ValueNormalized, global::System.Int64> setField0 = (global::System.Action<global::Common.Messages.ValueNormalized, global::System.Int64>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::Common.Messages.ValueNormalized input = ((global::Common.Messages.ValueNormalized)original);
            global::Common.Messages.ValueNormalized result = (global::Common.Messages.ValueNormalized)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.ValueNormalized));
            setField0(result, input.@DeviceId);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::Common.Messages.ValueNormalized input = (global::Common.Messages.ValueNormalized)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@DeviceId, stream, typeof (global::System.Int64));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::Common.Messages.ValueNormalized result = (global::Common.Messages.ValueNormalized)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::Common.Messages.ValueNormalized));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int64)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int64), stream));
            return (global::Common.Messages.ValueNormalized)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::Common.Messages.ValueNormalized), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenCommon_Messages_ValueNormalizedSerializer()
        {
            Register();
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
