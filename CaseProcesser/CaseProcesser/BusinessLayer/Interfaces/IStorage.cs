namespace CaseProcesser.BusinessLayer.Interfaces
{
    public interface IStorage<T, in TKey>
    {
        T Select(TKey id);
        void Insert(T data);
        void Update(T data);
        void Delete(TKey id);
    }

    /// <summary>
    ///   CRUD操作接口，主要针对Select的类型不同于存储类型的情况
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <typeparam name="TSelect">返回对象类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IStorage<in T, out TSelect, in TKey>
    {
        TSelect Select(TKey id);
        void Insert(T data);
        void Update(T data);
        void Delete(TKey id);
    }
}
