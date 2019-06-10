using System.Collections.Generic;
using WebApiAgenda.ViewModel.ViewModel;

namespace WebApiAgenda.Dao.Dao
{
    public interface IDao<T> where T : BaseViewModel
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T viewModel);
        bool Delete(int id);
        bool Edit(T viewModel);
    }
}
