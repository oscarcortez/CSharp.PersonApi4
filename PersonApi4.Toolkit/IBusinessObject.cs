namespace PersonApi4.Toolkit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBusinessObject<ModelType>
    {
        Task<ModelType> Add(ModelType model);

        Task<ModelType> Add(string storeProcedure);

        Task<ModelType> Update(ModelType model);

        Task Delete(ModelType model);

        IQueryable<ModelType> Query { get; }

        IQueryable<ModelType> GetSpQuery(string storeProcedure);

        event BeforeOperationEventHandler<ModelType> BeforeAdd;

        event BeforeOperationEventHandler<ModelType> BeforeUpdate;

        event BeforeOperationEventHandler<ModelType> BeforeDelete;

        event AfterOperationEventHandler<ModelType> AfterAdd;

        event AfterOperationEventHandler<ModelType> AfterUpdate;

        event AfterOperationEventHandler<ModelType> AfterDelete;

        event BeforeAnyOperationEventHandler<ModelType> BeforeOperation;

        event AfterAnyOperationEventHandler<ModelType> AfterOperation;
    }
}
