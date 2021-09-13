using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel
{
  public class PaginatedItemsViewModel<TEntity> where TEntity :class
  {
        private List<BasicLessonViewModel> vml;

        public PaginatedItemsViewModel(int pageSize, int totalPageCount, int totalRecordCount, List<BasicLessonViewModel> vml)
        {
            PageSize = pageSize;
            TotalPageCount = totalPageCount;
            TotalRecordCount = totalRecordCount;
            this.vml = vml;
        }

        public PaginatedItemsViewModel(int currentPage,int pageSize,int totalPageCount,int totalRecordCount, IEnumerable<TEntity> data)
    {
      this.CurrentPage = currentPage;
      this.PageSize = pageSize;
      this.TotalPageCount = totalPageCount;
      this.TotalRecordCount = totalRecordCount;
      this.Data = data;
    }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPageCount { get; set; }
    public int TotalRecordCount { get; set; }
    public IEnumerable<TEntity> Data { get; set; }
  }
}
