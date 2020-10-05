using RealEstateAgency.Data;
using System;
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
        private readonly IFilter _filter;
        public DGridEntityManager(DataGrid entitiesDGrid, IFilter filter)
        {
            var data = AgencyModel.Instance.Set<TEntity>().ToList();
             _entitiesDGrid = entitiesDGrid;
            _entitiesDGrid.ItemsSource = data;
            _filter = filter;
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
            AgencyModel.Instance.ChangeTracker.Entries().ToList().ForEach(item => item.Reload());
            _entitiesDGrid.ItemsSource = AgencyModel.Instance.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Применят фильтр к таблице.
        /// </summary>
        public void UseFilter(string pattern)
        {
            _entitiesDGrid.ItemsSource = _filter.Filter(AgencyModel
                .Instance.Set<TEntity>().ToList(), pattern).Cast<TEntity>();
        }
    }
}
