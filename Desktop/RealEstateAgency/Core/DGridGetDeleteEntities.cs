using RealEstateAgency.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency
{
    /// <summary>
    /// Реализует удаление, просмотр и фильтрацию для таблицы аргумента.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    class DGridEntityManager<TEntity> where TEntity : class, new()
    {
        private DataGrid _entitiesDGrid;
        private IFilter _filter;
        public DGridEntityManager(DataGrid entitiesDGrid, IFilter filter)
        {
            var data = RealEstateAgencyEntities.Instance.Set<TEntity>().ToArray();
            _entitiesDGrid = entitiesDGrid;
            _entitiesDGrid.ItemsSource = data;
            _filter = filter;
            filter.Context = data;
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
                    RealEstateAgencyEntities.Instance.Set<TEntity>().RemoveRange(selectedItems);
                    RealEstateAgencyEntities.Instance.SaveChanges();
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
            RealEstateAgencyEntities.Instance.ChangeTracker.Entries().ToList().ForEach(item => item.Reload());
            _entitiesDGrid.ItemsSource = RealEstateAgencyEntities.Instance.Set<TEntity>().ToArray();
        }

        /// <summary>
        /// Применят фильтр к таблице.
        /// </summary>
        public void UseFilter(string pattern)
        {
            _entitiesDGrid.ItemsSource = _filter.GetFilteredPersonInfos(pattern).Cast<TEntity>();
        }
    }
}
