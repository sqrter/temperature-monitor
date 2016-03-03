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
                        case -1732333552:
                            return "SayHello";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1618503141 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task<global::System.String> @SayHello()
        {
            return base.@InvokeMethodAsync<global::System.String>(-1732333552, null);
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
                            case -1732333552:
                                return ((global::GrainInterfaces.IPrinter)@grain).@SayHello().@Box();
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
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
