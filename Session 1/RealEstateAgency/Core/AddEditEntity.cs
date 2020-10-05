using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RealEstateAgency
{
    /// <summary>
    /// Статус для страниц, где можно, как создавать, так и редактировать.
    /// </summary>
    enum AddEditEntityOperation
    {
        Add, Edit
    }

    class AddEditEntity<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Сущность которая в данный момент редактируется или создается, в зависимости от AddEditEntityOperation.
        /// </summary>
        public TEntity EditEntity { get; set; }
        /// <summary>
        /// Вызывается при сохранение изменений.
        /// </summary>
        public event EventHandler SuccsessSaved;

        private readonly UserErrorCheack[] _userErrorCheacks;
        private readonly AddEditEntityOperation _currentOperation;

        /// <summary>
        /// Редактирование выбранной сущности.
        /// </summary>
        /// <param name="editClient">В случае равентсва null страница переходет в режим создания новой сущности.</param>
        public AddEditEntity(TEntity editEntity, UserErrorCheack[] userErrors)
        {
            if(editEntity == null)
            {
                EditEntity = new TEntity();
                _currentOperation = AddEditEntityOperation.Add;
            }
            else
            {
                EditEntity = editEntity;
                _currentOperation = AddEditEntityOperation.Edit;
            }
            _userErrorCheacks = userErrors;
        }

        /// <summary>
        /// Сохраняет изменения в базу данных.
        /// </summary>
        public void Save()
        {
            var errors = new ErrorBuilder();

            foreach(var userErrorCheack in _userErrorCheacks)
            {
                errors.AssertError(userErrorCheack.СheckFunc(), userErrorCheack.Message);
            }

            if(errors.IsAnyError())
            {
                throw new AddEditEntitySaveException(errors.GetMessage());
            }

            SetEntityWhiteSpaceStringsNull(EditEntity);


            if(_currentOperation == AddEditEntityOperation.Add)
            {
                AgencyModel.Instance.Set<TEntity>().Add(EditEntity);
            }

            try
            {
                AgencyModel.Instance.SaveChanges();
                SuccsessSaved.Invoke(this, new EventArgs());
            }
            catch
            {
                throw new AddEditEntitySaveException();
            }
        }

        /// <summary>
        /// Изменяет значение всех "белых пространств" в строках сущеностей на null.
        /// </summary>
        private void SetEntityWhiteSpaceStringsNull(TEntity entity)
        {
            var stringProperties = typeof(TEntity).GetProperties().Where(prop => prop.PropertyType == typeof(string));
            foreach(var stringProperty in stringProperties)
            {
                if(String.IsNullOrWhiteSpace((string)stringProperty.GetValue(entity)))
                {
                    stringProperty.SetValue(entity, null);
                }
            }
        }
    }

    /// <summary>
    /// Ошибка выданная классом AddEditEntitySave при сохранении.
    /// </summary>
    [Serializable]
    public class AddEditEntitySaveException : Exception
    {
        public AddEditEntitySaveException() { }
        public AddEditEntitySaveException(string message) : base(message) { }
        public AddEditEntitySaveException(string message, Exception inner) : base(message, inner) { }
        protected AddEditEntitySaveException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
