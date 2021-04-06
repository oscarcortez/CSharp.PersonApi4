namespace PersonApi4.Toolkit
{
    public delegate void BeforeOperationEventHandler<ModelType>(ModelType model, bool prevent);

    public delegate void AfterOperationEventHandler<ModelType>(ModelType model);

    public delegate void BeforeAnyOperationEventHandler<ModelType>(string operation, ModelType model, bool prevent);

    public delegate void AfterAnyOperationEventHandler<ModelType>(string operation, ModelType model);
}
