using System.Collections.Generic;
using Opc.Ua;

namespace Quickthiss.EmptyServer
{
    public class TestMethod: MethodState
    {
        private ushort NamespaceIndex;
        public TestMethod(NodeState parent, ushort NamespaceIndex) : base(parent)
        {
            this.NodeId = new NodeId(4, NamespaceIndex);
            this.BrowseName = new QualifiedName("this", NamespaceIndex);
            this.DisplayName = this.BrowseName.Name;
            this.ReferenceTypeId = ReferenceTypeIds.HasComponent;
            this.UserExecutable = true;
            this.Executable = true;
            this.NamespaceIndex = NamespaceIndex;

            this.OnCallMethod = new GenericMethodCalledEventHandler(OnStart);
        }

        public void AddOutputArgs()
        {
            this.OutputArguments = new PropertyState<Argument[]>(this);
            this.OutputArguments.NodeId = new NodeId(5, NamespaceIndex);
            this.OutputArguments.BrowseName = BrowseNames.OutputArguments;
            this.OutputArguments.DisplayName = this.OutputArguments.BrowseName.Name;
            this.OutputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
            this.OutputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            this.OutputArguments.DataType = DataTypeIds.Argument;
            this.OutputArguments.ValueRank = ValueRanks.OneDimension;
            Argument[] args = new Argument[2];
            args = new Argument[2];
            args[0] = new Argument();
            args[0].Name = "Revised Initial State";
            args[0].Description = "The revised initialize state for the process.";
            args[0].DataType = DataTypeIds.UInt32;
            args[0].ValueRank = ValueRanks.Scalar;

            args[1] = new Argument();
            args[1].Name = "Revised Final State";
            args[1].Description = "The revised final state for the process.";
            args[1].DataType = DataTypeIds.UInt32;
            args[1].ValueRank = ValueRanks.Scalar;

            this.OutputArguments.Value = args;
        }

        public ServiceResult OnStart(
            ISystemContext context,
            MethodState method,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            return ServiceResult.Good;
        }

        public void AddInputArgs()
        {
            this.InputArguments = new PropertyState<Argument[]>(this);
            this.InputArguments.NodeId = new NodeId(5, NamespaceIndex);
            this.InputArguments.BrowseName = BrowseNames.InputArguments;
            this.InputArguments.DisplayName = this.InputArguments.BrowseName.Name;
            this.InputArguments.TypeDefinitionId = VariableTypeIds.PropertyType;
            this.InputArguments.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            this.InputArguments.DataType = DataTypeIds.Argument;
            this.InputArguments.ValueRank = ValueRanks.OneDimension;

            Argument[] args = new Argument[2];
            args[0] = new Argument();
            args[0].Name = "Initial State";
            args[0].Description = "The initialize state for the process.";
            args[0].DataType = DataTypeIds.UInt32;
            args[0].ValueRank = ValueRanks.Scalar;

            args[1] = new Argument();
            args[1].Name = "Final State";
            args[1].Description = "The final state for the process.";
            args[1].DataType = DataTypeIds.UInt32;
            args[1].ValueRank = ValueRanks.Scalar;

            this.InputArguments.Value = args;
        }
    }
}
