#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("GrainInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace GrainInterfaces
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::GrainInterfaces.IDevice))]
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
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 1233120812 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::GrainInterfaces.IDevice", 1233120812, typeof (global::GrainInterfaces.IDevice)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
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

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::GrainInterfaces.IPrinter))]
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

        public global::System.Threading.Tasks.Task @PrintAverage(global::TemperatureMonitor.Messages.AverageTemperature @data)
        {
            return base.@InvokeMethodAsync<global::System.Object>(72318212, new global::System.Object[]{@data});
        }

        public global::System.Threading.Tasks.Task @ThresholdExceeded(global::TemperatureMonitor.Messages.ThresholdExceeded @msg)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-816558819, new global::System.Object[]{@msg});
        }

        public global::System.Threading.Tasks.Task @ValueNormalized(global::TemperatureMonitor.Messages.ValueNormalized @msg)
        {
            return base.@InvokeMethodAsync<global::System.Object>(-2006791096, new global::System.Object[]{@msg});
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::GrainInterfaces.IPrinter", -1618503141, typeof (global::GrainInterfaces.IPrinter)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
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
                                return ((global::GrainInterfaces.IPrinter)@grain).@PrintAverage((global::TemperatureMonitor.Messages.AverageTemperature)@arguments[0]).@Box();
                            case -816558819:
                                return ((global::GrainInterfaces.IPrinter)@grain).@ThresholdExceeded((global::TemperatureMonitor.Messages.ThresholdExceeded)@arguments[0]).@Box();
                            case -2006791096:
                                return ((global::GrainInterfaces.IPrinter)@grain).@ValueNormalized((global::TemperatureMonitor.Messages.ValueNormalized)@arguments[0]).@Box();
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

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::TemperatureMonitor.Messages.AverageTemperature)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenTemperatureMonitor_Messages_AverageTemperatureSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::TemperatureMonitor.Messages.AverageTemperature).@GetField("<Value>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::TemperatureMonitor.Messages.AverageTemperature, global::System.Double> setField0 = (global::System.Action<global::TemperatureMonitor.Messages.AverageTemperature, global::System.Double>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::TemperatureMonitor.Messages.AverageTemperature input = ((global::TemperatureMonitor.Messages.AverageTemperature)original);
            global::TemperatureMonitor.Messages.AverageTemperature result = (global::TemperatureMonitor.Messages.AverageTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.AverageTemperature));
            setField0(result, input.@Value);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::TemperatureMonitor.Messages.AverageTemperature input = (global::TemperatureMonitor.Messages.AverageTemperature)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@Value, stream, typeof (global::System.Double));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::TemperatureMonitor.Messages.AverageTemperature result = (global::TemperatureMonitor.Messages.AverageTemperature)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.AverageTemperature));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Double)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Double), stream));
            return (global::TemperatureMonitor.Messages.AverageTemperature)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::TemperatureMonitor.Messages.AverageTemperature), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenTemperatureMonitor_Messages_AverageTemperatureSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::TemperatureMonitor.Messages.ThresholdExceeded)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenTemperatureMonitor_Messages_ThresholdExceededSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::TemperatureMonitor.Messages.ThresholdExceeded).@GetField("<DeviceId>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::TemperatureMonitor.Messages.ThresholdExceeded, global::System.Int32> setField0 = (global::System.Action<global::TemperatureMonitor.Messages.ThresholdExceeded, global::System.Int32>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::TemperatureMonitor.Messages.ThresholdExceeded input = ((global::TemperatureMonitor.Messages.ThresholdExceeded)original);
            global::TemperatureMonitor.Messages.ThresholdExceeded result = (global::TemperatureMonitor.Messages.ThresholdExceeded)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.ThresholdExceeded));
            setField0(result, input.@DeviceId);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::TemperatureMonitor.Messages.ThresholdExceeded input = (global::TemperatureMonitor.Messages.ThresholdExceeded)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@DeviceId, stream, typeof (global::System.Int32));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::TemperatureMonitor.Messages.ThresholdExceeded result = (global::TemperatureMonitor.Messages.ThresholdExceeded)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.ThresholdExceeded));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int32), stream));
            return (global::TemperatureMonitor.Messages.ThresholdExceeded)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::TemperatureMonitor.Messages.ThresholdExceeded), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenTemperatureMonitor_Messages_ThresholdExceededSerializer()
        {
            Register();
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.0.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::TemperatureMonitor.Messages.ValueNormalized)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenTemperatureMonitor_Messages_ValueNormalizedSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::TemperatureMonitor.Messages.ValueNormalized).@GetField("<DeviceId>k__BackingField", (System.@Reflection.@BindingFlags.@Public | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Instance));
        private static readonly global::System.Action<global::TemperatureMonitor.Messages.ValueNormalized, global::System.Int32> setField0 = (global::System.Action<global::TemperatureMonitor.Messages.ValueNormalized, global::System.Int32>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::TemperatureMonitor.Messages.ValueNormalized input = ((global::TemperatureMonitor.Messages.ValueNormalized)original);
            global::TemperatureMonitor.Messages.ValueNormalized result = (global::TemperatureMonitor.Messages.ValueNormalized)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.ValueNormalized));
            setField0(result, input.@DeviceId);
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::TemperatureMonitor.Messages.ValueNormalized input = (global::TemperatureMonitor.Messages.ValueNormalized)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(input.@DeviceId, stream, typeof (global::System.Int32));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::TemperatureMonitor.Messages.ValueNormalized result = (global::TemperatureMonitor.Messages.ValueNormalized)global::System.Runtime.Serialization.FormatterServices.@GetUninitializedObject(typeof (global::TemperatureMonitor.Messages.ValueNormalized));
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int32), stream));
            return (global::TemperatureMonitor.Messages.ValueNormalized)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::TemperatureMonitor.Messages.ValueNormalized), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenTemperatureMonitor_Messages_ValueNormalizedSerializer()
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
