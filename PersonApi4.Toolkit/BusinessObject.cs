namespace PersonApi4.Toolkit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class BusinessObject<ModelType> : IBusinessObject<ModelType> where ModelType : new()
    {
        private IStorageProvider<ModelType> storageProvider;

        public IQueryable<ModelType> Query => this.storageProvider.Get().AsQueryable();

        public IQueryable<ModelType> GetSpQuery(string storeProcedure)
        {
            return JsonConvert.DeserializeObject<IList<ModelType>>(storageProvider.Get(storeProcedure)).AsQueryable();
        }

        public async Task<ModelType> Add(string storeProcedure)
        {            
            return JsonConvert.DeserializeObject<ModelType>(await storageProvider.Save(storeProcedure));
        }

        public BusinessObject(IStorageProvider<ModelType> storageProvider)
        {
            this.storageProvider = storageProvider;
        }

        public event BeforeOperationEventHandler<ModelType> BeforeAdd;// asdfasdf

        public event BeforeOperationEventHandler<ModelType> BeforeUpdate;

        public event BeforeOperationEventHandler<ModelType> BeforeDelete;

        public event AfterOperationEventHandler<ModelType> AfterAdd;

        public event AfterOperationEventHandler<ModelType> AfterUpdate;

        public event AfterOperationEventHandler<ModelType> AfterDelete;

        public event BeforeAnyOperationEventHandler<ModelType> BeforeOperation;

        public event AfterAnyOperationEventHandler<ModelType> AfterOperation;

        public async Task<ModelType> Add(ModelType model)
        {
            bool prevent = false;
            if (this.BeforeAdd != null)
            {
                this.BeforeAdd(model, prevent);
            }

            if (!prevent)
            {
                // TODO: Do something in the storage
                // ModelType addedModel = default(ModelType);
                var addedModel = await this.storageProvider.Save(model);
                if (this.AfterAdd != null)
                {
                    this.AfterAdd(addedModel);
                }

                if (this.AfterOperation != null)
                {
                    this.AfterOperation("add", addedModel);
                }

                return addedModel;
            }
            else
            {
                // TODO: Resolve how to return when a preventing
                // Remove the return line, shall we raise an exception?
                return model;
            }
        }

        public Task Delete(ModelType model)
        {
            throw new NotImplementedException();
        }

        public Task<ModelType> Update(ModelType model)
        {
            throw new NotImplementedException();
        }
    }
}
