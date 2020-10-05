using RealEstateAgency;
using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency
{
    /// <summary>
    /// Реализует удаление, просмотр и фильтрацию для таблицы аргумента.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    class DGridEntityManager<TEntity> where TEntity : class
    {
        private readonly DataGrid _entitiesDGrid;
        private readonly UserErrorCheack[] _userErrorCheacks;
        private Dictionary<string, FilterWithPattern> usingFilters;

        public DGridEntityManager(DataGrid entitiesDGrid, UserErrorCheack[] userErrors)
        {
            var data = AgencyModel.Instance.Set<TEntity>().ToList();
             _entitiesDGrid = entitiesDGrid;
            _entitiesDGrid.ItemsSource = data;
            _userErrorCheacks = userErrors;

            usingFilters = new Dictionary<string, FilterWithPattern>();
        }

        public DGridEntityManager(DataGrid entitiesDGrid) : this(entitiesDGrid, new UserErrorCheack[0])
        {
        }

        public IEnumerable<TEntity> AllEntities => AgencyModel.Instance.Set<TEntity>().ToList();
        public IEnumerable<TEntity> DisplayedEntities => (IEnumerable<TEntity>)_entitiesDGrid.ItemsSource;

        /// <summary>
        /// Использование фильтрации для элементов DataGrid.
        /// Добавляет фильтр в коллекцию фильтров и применяет его если фильтра с указаным именем еще не пременено.
        /// Если фильтр с указаным именем существует, заменяет его.
        /// </summary>
        /// <param name="filterName">Название фильтра</param>
        /// <param name="filter"></param>
        /// <param name="pattern"></param>
        public void UseFilter(string filterName, ICollectionFilter filter, string pattern)
        {
            var filterForUse = new FilterWithPattern { Pattern = pattern, Filter = filter };

            if(!usingFilters.ContainsKey(filterName))
            {
                usingFilters.Add(filterName, new FilterWithPattern { Pattern = pattern, Filter = filter });
            }
            else
            {
                usingFilters[filterName] = filterForUse;
            }
            ReloadTable();
        }

        public bool IsFilterUsing(string filterName)
        {
            return usingFilters.ContainsKey(filterName);
        }
        public FilterWithPattern GetUsingFilter(string filterName)
        {
            return usingFilters[filterName];
        }
        public void RemoveFilter(string filterName)
        {
            usingFilters.Remove(filterName);
            ReloadTable();
        }

        public void ClearFilters()
        {
            usingFilters.Clear();
            ReloadTable();
        }

        /// <summary>
        /// Применят фильтр к таблице.
        /// </summary>
        public void RemoveSelected()
        {
            var selectedItems = _entitiesDGrid.SelectedItems.Cast<TEntity>().ToList();

            if(selectedItems.Count <= 0)
            {
                MessageBox.Show("Вы не выбрали не однин элемент для удаления!", "Выберите элементы",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if(MessageBox.Show($"Вы действительно хотите удалить {selectedItems.Count} элемента",
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var errors = new ErrorBuilder();
                    foreach(var userErrorCheack in _userErrorCheacks)
                    {
                        errors.AssertError(userErrorCheack.СheckFunc(), userErrorCheack.Message);
                    }

                    if(errors.IsAnyError())
                    {
                        throw new UserActionException(errors.GetMessage());
                    }

                    AgencyModel.Instance.Set<TEntity>().RemoveRange(selectedItems);
                    AgencyModel.Instance.SaveChanges();
                    
                    MessageBox.Show("Данные успешно удалены", "Успешно",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                    ReloadTable();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        /// <summary>
        /// Обновление таблицы.
        /// </summary>
        public void ReloadTable()
        {
            ReloadTableWithoutFilters();
            foreach(var item in usingFilters)
            {
                _entitiesDGrid.ItemsSource = item.Value.UseFilter(_entitiesDGrid.ItemsSource);
            }
        }

        private void ReloadTableWithoutFilters()
        {
            AgencyModel.Instance.ChangeTracker.Entries().ToList().ForEach(item => item.Reload());
            _entitiesDGrid.ItemsSource = AgencyModel.Instance.Set<TEntity>().ToList();
        }
    }
}
